
USE FlexTrainer2;

SELECT * FROM Member;
SELECT * FROM Trainer;
SELECT * FROM Gym_Owner;
SELECT * FROM Gym;
SELECT * FROM Member_Registration;
SELECT * FROM MemberjoinGym;
SELECT * FROM Trainer_Registration;
SELECT * FROM Gym_Owner_Registration;
SELECT * FROM Gym_Registration;
SELECT * FROM TrainerWorksGym;
SELECT * FROM MemberTrainerSession;
SELECT * FROM MemberFeedback;
SELECT * FROM TrainerAvailability;
SELECT * FROM TrainerSpecialty;
SELECT * FROM TrainerQualification;
SELECT * FROM TrainerRegistrationSpecialty;
SELECT * FROM TrainerRegistrationQualification;
SELECT * FROM GymApprovesTrainer;
SELECT * FROM Admin;
SELECT * FROM Equipment;
SELECT * FROM GymUsesEquipment;
SELECT * FROM Workout_Log;
SELECT * FROM Diet_Log;
SELECT * FROM Workout_Plan;
SELECT * FROM WorkoutUsesEquipment;
SELECT * FROM Diet_Plan;
SELECT * FROM Diet;
SELECT * FROM DietPlanUsesDiet;
SELECT * FROM Membership;
SELECT * FROM MemberHasGymMembership;
SELECT * FROM WeeklyPlan;



--------------------------------------------------------------------------------------------------------
--                                            WORKOUT PLAN                                            --
--------------------------------------------------------------------------------------------------------
-- return deatls of workou plan name, category, target muscle, exercise name, reps, sets, equipment name
CREATE OR ALTER FUNCTION GetWorkoutEquipmentDetails( @UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT wp.Workout_ID,
           wp.Name AS Workout_Name, 
           wp.Category AS Workout_Category, 
           wp.Target_Muscle, 
           e.Name AS Equipment_Name, 
           wue.Sets, 
           wue.Reps,
           wp.Total_Time,
           wp.Public_Flag
    FROM Workout_Plan wp
    JOIN WorkoutUsesEquipment wue ON wp.Workout_ID = wue.Workout_ID
    JOIN Equipment e ON wue.Equipment_ID = e.Equipment_ID
    WHERE (wp.Public_Flag = 1 OR COALESCE(wp.Member_SSN, wp.Trainer_SSN) = @UserID)
    
    UNION ALL
    
    SELECT wp.Workout_ID,
           wp.Name AS Workout_Name, 
           wp.Category AS Workout_Category, 
           wp.Target_Muscle, 
           NULL AS Equipment_Name, 
           NULL AS Sets, 
           NULL AS Reps,
           wp.Total_Time,
           wp.Public_Flag
    FROM Workout_Plan wp
    WHERE NOT EXISTS (
        SELECT 1
        FROM WorkoutUsesEquipment wue
        WHERE wp.Workout_ID = wue.Workout_ID
    ) AND (wp.Public_Flag = 1 OR COALESCE(wp.Member_SSN, wp.Trainer_SSN) = @UserID)
);


-- return private workout plans using user id
CREATE OR ALTER FUNCTION GetPrivateWorkoutEquipmentDetails(@UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetWorkoutEquipmentDetails(@UserID)
    WHERE Public_Flag = 0
);


-- return all muscltypes using workout plan
CREATE OR ALTER FUNCTION GetMuscleTypes()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT Target_Muscle
    FROM Workout_Plan
);


-- return all workout plans using muscle type
CREATE OR ALTER FUNCTION GetWorkoutEquipmentDetailsByMuscle(@MuscleType VARCHAR(50),@UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetWorkoutEquipmentDetails(@UserID)
    WHERE Target_Muscle = @MuscleType
);


-- return all Workout Category
CREATE OR ALTER FUNCTION GetWorkoutCategory()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT Category
    FROM Workout_Plan
);


-- return all workout plans using category
CREATE OR ALTER FUNCTION GetWorkoutEquipmentDetailsByCategory(@Category VARCHAR(50),@UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetWorkoutEquipmentDetails(@UserID)
    WHERE Workout_Category = @Category
);


-- return workout plan using workout name also cater in complete name
CREATE OR ALTER FUNCTION GetWorkoutEquipmentDetailsByName(@WorkoutName VARCHAR(50),@UserID VARCHAR(11)) 
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetWorkoutEquipmentDetails(@UserID)
    WHERE Workout_Name LIKE '%' + @WorkoutName + '%'

);


CREATE OR ALTER FUNCTION GetWorkoutEquipmentDetailsByFilters(@MuscleType VARCHAR(50), @Category VARCHAR(50), @WorkoutName VARCHAR(50), @UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetWorkoutEquipmentDetails(@UserID)
    WHERE
    ((@MuscleType = 'All') OR (Target_Muscle = @MuscleType))
    AND
    ((@Category = 'All') OR (Workout_Category = @Category))
    AND
    ((@WorkoutName = 'All') OR (Workout_Name LIKE '%' + @WorkoutName + '%'))
    AND
    ((@MuscleType != 'All') OR (Target_Muscle = Target_Muscle))
);

SELECT * FROM GetWorkoutEquipmentDetails('') WHERE Workout_ID = 1
SELECT * FROM GetWorkoutEquipmentDetails('T_001')
SELECT * FROM GetPrivateWorkoutEquipmentDetails('12345678901')
SELECT * FROM GetMuscleTypes()
SELECT * FROM GetWorkoutEquipmentDetailsByMuscle('Chest','')
SELECT * FROM GetWorkoutCategory()
SELECT * FROM GetWorkoutEquipmentDetailsByCategory('Strength','12345678901')
SELECT * FROM GetWorkoutEquipmentDetailsByName('Workout','12345678901')
SELECT * FROM GetWorkoutEquipmentDetailsByFilters('Chest', 'All', 'Workou','')

-- create workoutplan and also add equipment to it also handle all attributes non-nullable also use try catch and return 1,0
CREATE OR ALTER PROCEDURE CreateWorkoutPlan(
    @Name VARCHAR(50),
    @PublicFlag BIT,
    @Category VARCHAR(50),
    @TargetMuscle VARCHAR(50),
    @TotalTime INT,
    @MemberSSN VARCHAR(11),
    @TrainerSSN VARCHAR(11),
    @EquipmentID INT,
    @Sets INT,
    @Reps INT
)
AS
BEGIN
    BEGIN TRY
        DECLARE @WorkoutID INT;
        -- Auto assign workout ID
        SET @WorkoutID = (SELECT ISNULL(MAX(Workout_ID), 0) + 1 FROM Workout_Plan);
        INSERT INTO Workout_Plan (Workout_ID, Name, Public_Flag, Category, Target_Muscle, Total_Time, Member_SSN, Trainer_SSN)
        VALUES (@WorkoutID, @Name, @PublicFlag, @Category, @TargetMuscle, @TotalTime, @MemberSSN, @TrainerSSN);
        INSERT INTO WorkoutUsesEquipment (Workout_ID, Equipment_ID, Sets, Reps)
        VALUES (@WorkoutID, @EquipmentID, @Sets, @Reps);
        SELECT 1 AS status, @WorkoutID AS workout_id;
    END TRY
    BEGIN CATCH
        SELECT 0 AS status,ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

EXEC CreateWorkoutPlan 'Testing 2', 0, 'Strength', 'Chest', 40, '12345678901', NULL, 1, 3, 12
-- SELECT * FROM GetWorkoutEquipmentDetails('12345678901')

-- add quipment in workout plan
CREATE OR ALTER PROCEDURE AddEquipmentToWorkoutPlan(
    @WorkoutID INT,
    @EquipmentID INT,
    @Sets INT,
    @Reps INT
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO WorkoutUsesEquipment (Workout_ID, Equipment_ID, Sets, Reps)
        VALUES (@WorkoutID, @EquipmentID, @Sets, @Reps);
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC AddEquipmentToWorkoutPlan 4, 1, 7, 10
SELECT * FROM GetWorkoutEquipmentDetails('12345678801') 

--------------------------------------------------------------------------------------------------------
--                                             Diet PLAN                                              --
--------------------------------------------------------------------------------------------------------

CREATE OR ALTER FUNCTION GetDietPlanDetails(@UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT dp.Diet_Plan_ID AS ID,
           dp.DietPlan_Name,
           dp.Type_Diet_Plan AS Type_diet_plan,
           dp.Time_Of_Day AS day_time,
           SUM(d.Fats * dpu.Quantity) AS total_fats,
           SUM(d.Calories * dpu.Quantity) AS total_cals,
           dp.Public_Flag
    FROM Diet_Plan dp
    LEFT JOIN DietPlanUsesDiet dpu ON dp.Diet_Plan_ID = dpu.Diet_Plan_ID
    LEFT JOIN Diet d ON dpu.Diet_ID = d.Diet_ID
    WHERE (dp.Public_Flag = 1 OR COALESCE(dp.Member_SSN, dp.Trainer_SSN) = @UserID)
    GROUP BY dp.Diet_Plan_ID, dp.DietPlan_Name, dp.Type_Diet_Plan, dp.Time_Of_Day, dp.Public_Flag
);


SELECT * FROM GetDietPlanDetails('')

-- return all type
CREATE OR ALTER FUNCTION GetDietType()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT Type_Diet_Plan
    FROM Diet_Plan
);
-- return all day time
CREATE OR ALTER FUNCTION GetDayTime()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT Time_Of_Day
    FROM Diet_Plan
);
-- return fats less than threshold
CREATE OR ALTER FUNCTION GetDietPlanDetailsByFats(@Threshold INT, @UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetDietPlanDetails(@UserID)
    WHERE total_fats < @Threshold
);
-- return cals less than threshold
CREATE OR ALTER FUNCTION GetDietPlanDetailsByCals(@Threshold INT, @UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetDietPlanDetails(@UserID)
    WHERE total_cals < @Threshold
);

-- return diet plan using diet name also cater in complete name
CREATE OR ALTER FUNCTION GetDietPlanDetailsByName(@DietName VARCHAR(50),@UserID VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetDietPlanDetails(@UserID)
    WHERE DietPlan_Name LIKE '%' + @DietName + '%'
);

SELECT * FROM GetDietType();
SELECT * FROM GetDayTime();
SELECT * FROM GetDietPlanDetailsByFats(100, '');
SELECT * FROM GetDietPlanDetailsByCals(3900, '');
SELECT * FROM GetDietPlanDetailsByName('Diet Plan ', '');

-- insert deit plan
CREATE OR ALTER PROCEDURE CreateDietPlan(
    @PublicFlag BIT,
    @DietPlanName VARCHAR(50),
    @TypeDietPlan VARCHAR(50),
    @TimeOfDay VARCHAR(50),
    @MemberSSN VARCHAR(11),
    @TrainerSSN VARCHAR(11),
    @DietID INT,
    @Quantity INT
)
AS
BEGIN
    BEGIN TRY
        DECLARE @DietPlanID INT;
        -- Auto assign diet plan ID
        SET @DietPlanID = (SELECT ISNULL(MAX(Diet_Plan_ID), 0) + 1 FROM Diet_Plan);
        INSERT INTO Diet_Plan (Diet_Plan_ID, Public_Flag, DietPlan_Name, Type_Diet_Plan, Time_Of_Day, Member_SSN, Trainer_SSN)
        VALUES (@DietPlanID, @PublicFlag, @DietPlanName, @TypeDietPlan, @TimeOfDay, @MemberSSN, @TrainerSSN);
        INSERT INTO DietPlanUsesDiet (Diet_Plan_ID, Diet_ID, Quantity)
        VALUES (@DietPlanID, @DietID, @Quantity);
        SELECT 1 AS status, @DietPlanID AS diet_plan_id;
    END TRY
    BEGIN CATCH
        SELECT 0 AS status,ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
    END CATCH
END;

EXEC CreateDietPlan 1, 'Diet Plan 12', 'Keto', 'Morning', NULL, 'T_001', 1, 1
SELECT * FROM GetDietPlanDetails('12345678901')

-- add diet in diet plan
CREATE OR ALTER PROCEDURE AddDietToDietPlan(
    @DietPlanID INT,
    @DietID INT,
    @Quantity INT
)
AS
BEGIN
    BEGIN TRY
        INSERT INTO DietPlanUsesDiet (Diet_Plan_ID, Diet_ID, Quantity)
        VALUES (@DietPlanID, @DietID, @Quantity);
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC AddDietToDietPlan 12, 2, 3
SELECT * FROM GetDietPlanDetails('')


--------------------------------------------------------------------------------------------------------
--                                             Gym Owner                                              --
--------------------------------------------------------------------------------------------------------

CREATE OR ALTER FUNCTION GetGymsByOwner(
    @OwnerSSN VARCHAR(11)
)
RETURNS TABLE
AS
RETURN
(
    SELECT G.GYM_SSN, G.Name AS Gym_Name, G.Location
    FROM Gym G
    JOIN Gym_Owner GO ON G.GO_SSN = GO.GO_SSN
    WHERE GO.GO_SSN = @OwnerSSN
);

SELECT * FROM GetGymsByOwner('GO_001')


CREATE OR ALTER FUNCTION GetTrainersByGym(
    @GymSSN VARCHAR(11)
)
RETURNS TABLE
AS
RETURN
(
    SELECT T.Trainer_SSN, T.Gender, T.Gmail, T.First_Name, T.Last_Name, T.YoE
    FROM Trainer T
    JOIN TrainerWorksGym TWG ON T.Trainer_SSN = TWG.Trainer_SSN
    WHERE TWG.GYM_SSN = @GymSSN
);

SELECT * FROM GetTrainersByGym('GYM_001')

-- get traner by %name% and gym
CREATE OR ALTER FUNCTION GetTrainersByGymAndName(
    @GymSSN VARCHAR(11),
    @TrainerName VARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetTrainersByGym(@GymSSN)
    WHERE (First_Name + ' ' + Last_Name) LIKE '%' + @TrainerName + '%'
);

SELECT * FROM GetTrainersByGymAndName('GYM_001', 'Trainer ')

-- get trainer by min yoe
CREATE OR ALTER FUNCTION GetTrainersByGymAndYoE(
    @GymSSN VARCHAR(11),
    @MinYoE FLOAT
)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetTrainersByGym(@GymSSN)
    WHERE YoE >= @MinYoE
);

SELECT * FROM GetTrainersByGymAndYoE('GYM_001','0')

-- remove traner from gym take gym id as refrence
CREATE OR ALTER PROCEDURE RemoveTrainerFromGym(
    @TrainerSSN VARCHAR(11),
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM TrainerWorksGym
        WHERE Trainer_SSN = @TrainerSSN AND GYM_SSN = @GymSSN;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC RemoveTrainerFromGym 'T_002', 'GYM_001'
--------------------------------------------------------------------------------------------------------------------------------------
-- return all members in the gym with membership type ,Member_SSN, Gender, Gmail, First_Name, Last_Name, Height, Weight 
CREATE OR ALTER FUNCTION GetMembersByGym(
    @GymSSN VARCHAR(11)
)
RETURNS TABLE
AS
RETURN
(
    SELECT m.Member_SSN, m.Gender, m.Gmail, m.First_Name, m.Last_Name, m.Height, m.Weight, 
           mgm.type_membership, 
           CASE WHEN GETDATE() > mgm.End_Date THEN 'Expired' ELSE 'Active' END AS Membership_Status,
           mgm.End_Date AS Expiration_Date
    FROM Member m
    JOIN (
        SELECT Member_SSN, type_membership, End_Date,
            ROW_NUMBER() OVER (PARTITION BY Member_SSN ORDER BY Start_Date DESC) AS RowNum
        FROM MemberHasGymMembership
        WHERE GYM_SSN = @GymSSN
    ) mgm ON m.Member_SSN = mgm.Member_SSN AND mgm.RowNum = 1
);


SELECT * FROM GetMembersByGym('GYM_001')

-- return all types of memberships
CREATE OR ALTER FUNCTION GetMembershipTypes()
RETURNS TABLE
AS
RETURN
(
    SELECT DISTINCT type_membership
    FROM MemberHasGymMembership
);

SELECT * FROM GetMembershipTypes()

-- GetMembersByGym by %full name%
CREATE OR ALTER FUNCTION GetMembersByGymAndName(
    @GymSSN VARCHAR(11),
    @MemberName VARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM GetMembersByGym(@GymSSN)
    WHERE (First_Name + ' ' + Last_Name) LIKE '%' + @MemberName + '%'
);

SELECT * FROM GetMembersByGymAndName('GYM_001', 'Sophia White')

-- remove selected member from gym
CREATE OR ALTER PROCEDURE RemoveMemberFromGym(
    @MemberSSN VARCHAR(11),
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM MemberHasGymMembership
        WHERE Member_SSN = @MemberSSN AND GYM_SSN = @GymSSN;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC RemoveMemberFromGym '12345678901', 'GYM_001'


-- return all memberregistration requests
CREATE OR ALTER FUNCTION GetMemberRegistrationRequests()
RETURNS TABLE
AS
RETURN
(
    SELECT MR.Member_SSN, MR
    FROM MemberRegistration MR
    WHERE MR.Approved_Flag = 0
);
--------------------------------------------------------------------------------------------------------
--                                             Requests                                               --
--------------------------------------------------------------------------------------------------------
-- Create member registration request
CREATE OR ALTER PROCEDURE CreateMemberRegistrationRequest(
    @MemberSSN VARCHAR(11),
    @Gender VARCHAR(10),
    @Gmail VARCHAR(100),
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Height FLOAT,
    @Weight FLOAT,
    @Password VARCHAR(50),
    @GymID VARCHAR(11)
)
AS
BEGIN
    -- Check if the Member SSN already exists in the database
    IF EXISTS (SELECT 1 FROM Member_Registration WHERE Member_SSN = @MemberSSN)
    BEGIN
        SELECT 2 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Member WHERE Member_SSN = @MemberSSN)
    BEGIN
        SELECT 3 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Member_Registration WHERE Gmail = @Gmail)
    BEGIN
        SELECT 4 AS status; -- Indicate failure (Gmail already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Member WHERE Gmail = @Gmail)
    BEGIN
        SELECT 5 AS status; -- Indicate failure (Gmail already exists)
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Member_Registration (Member_SSN, Gender, Gmail, First_Name, Last_Name, Height, Weight, Password, GYM_SSN)
        VALUES (@MemberSSN, @Gender, @Gmail, @FirstName, @LastName, @Height, @Weight, @Password, @GymID);
        
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status; -- Indicate failure (insertion error)
    END CATCH
END;

-- Create trainer registration request
CREATE OR ALTER PROCEDURE CreateTrainerRegistrationRequest(
    @TrainerSSN VARCHAR(11),
    @Gender VARCHAR(10),
    @Gmail VARCHAR(100),
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @YoE FLOAT,
    @Password VARCHAR(50),
    @GymID VARCHAR(11)
)
AS
BEGIN
    -- Check if the Trainer SSN already exists in the database
    IF EXISTS (SELECT 1 FROM Trainer_Registration WHERE Trainer_SSN = @TrainerSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Trainer WHERE Trainer_SSN = @TrainerSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Trainer_Registration WHERE Gmail = @Gmail)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (Gmail already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Trainer WHERE Gmail = @Gmail)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (Gmail already exists)
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Trainer_Registration (Trainer_SSN, Gender, Gmail, First_Name, Last_Name, YoE, Password, GYM_SSN)
        VALUES (@TrainerSSN, @Gender, @Gmail, @FirstName, @LastName, @YoE, @Password, @GymID);
        

        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status; -- Indicate failure (insertion error)
    END CATCH
END;

-- create gym owner registration request
CREATE OR ALTER PROCEDURE CreateGymOwnerRegistrationRequest(
    @GymOwnerSSN VARCHAR(11),
    @Gender VARCHAR(10),
    @Gmail VARCHAR(100),
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Password VARCHAR(50)
)
AS
BEGIN
    -- Check if the Gym Owner SSN already exists in the database
    IF EXISTS (SELECT 1 FROM Gym_Owner_Registration WHERE GO_SSN = @GymOwnerSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Gym_Owner WHERE GO_SSN = @GymOwnerSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Gym_Owner_Registration (GO_SSN, Gender, Gmail, First_Name, Last_Name, Password)
        VALUES (@GymOwnerSSN, @Gender, @Gmail, @FirstName, @LastName, @Password);
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status; -- Indicate failure (insertion error)
    END CATCH
END;


EXEC CreateMemberRegistrationRequest '12345612325', 'Male', 'tes@gmail.com', 'John', 'Doe', 5, 70, 'password123', 12345678902
EXEC CreateMemberRegistrationRequest '12345678910', 'Female', 'example1@gmail.com', 'Alice', 'Smith', 5.5, 60, 'password123', '12345678902';
EXEC CreateMemberRegistrationRequest '12345678911', 'Male', 'example2@gmail.com', 'Bob', 'Johnson', 6, 75, 'password456', '12345678902';
EXEC CreateMemberRegistrationRequest '12345678912', 'Female', 'example3@gmail.com', 'Emily', 'Brown', 5.8, 65, 'password789', '12345678902';
EXEC CreateMemberRegistrationRequest '12345678913', 'Male', 'example4@gmail.com', 'David', 'Wilson', 5.9, 80, 'passwordabc', '12345678902';
EXEC CreateMemberRegistrationRequest '12345678914', 'Female', 'example5@gmail.com', 'Emma', 'Martinez', 5.6, 70, 'passwordxyz', '12345678902';

EXEC CreateTrainerRegistrationRequest 'T_002', 'M', 'trainer@gmail.com', 'Trainer', 'Trainer', 2, 'password456', 12345678902
-- Sample data to test Trainer registration
INSERT INTO Trainer_Registration (Trainer_SSN, Gender, Gmail, First_Name, Last_Name, YoE, Password, GYM_SSN)
VALUES ('T_211', 'M', 'trainer1@gmail.com', 'John', 'Doe', 5, 'password123', '12345678902'),
       ('T_212', 'M', 'trainer2@gmail.com', 'Jane', 'Smith', 3, 'password456', '12345678902'),
       ('T_213', 'F', 'trainer3@gmail.com', 'Emma', 'Johnson', 2, 'password789', '12345678902'),
       ('T_214', 'M', 'trainer4@gmail.com', 'Michael', 'Williams', 4, 'passwordabc', '12345678902'),
       ('T_215', 'F', 'trainer5@gmail.com', 'Emily', 'Brown', 6, 'passworddef', '12345678902'),
       ('T_216', 'M', 'trainer6@gmail.com', 'Matthew', 'Jones', 1, 'passwordghi', '12345678902');

EXEC CreateGymOwnerRegistrationRequest 'GO_001', 'M', 'owner@gmail.com', 'Owner', 'Owner', 'password789'

-- return all member requests by specific gym
CREATE OR ALTER FUNCTION GetMemberRegistrationRequestsByGym(
    @GymSSN VARCHAR(11)
)
RETURNS TABLE
AS
RETURN
(
    SELECT MR.Member_SSN, MR.Gender, MR.Gmail, MR.First_Name, MR.Last_Name, MR.Height, MR.Weight
    FROM Member_Registration MR
    WHERE MR.GYM_SSN = @GymSSN
);


SELECT * FROM GetMemberRegistrationRequestsByGym('12345678902')

-- return all trainer requests by specific gym
CREATE OR ALTER FUNCTION GetTrainerRegistrationRequestsByGym(
    @GymSSN VARCHAR(11)
)
RETURNS TABLE
AS
RETURN
(
    SELECT TR.Trainer_SSN, TR.Gender, TR.Gmail, TR.First_Name, TR.Last_Name, TR.YoE
    FROM Trainer_Registration TR
    WHERE TR.GYM_SSN = @GymSSN
);


SELECT * FROM GetTrainerRegistrationRequestsByGym('12345678903')

-- aprove member request by gym
-- Sample data for initial membership
INSERT INTO MemberHasGymMembership (Member_SSN, GYM_SSN, Start_Date, End_Date, type_membership)
VALUES ('12345612325', '12345678902', GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular'),
       ('12345678910', '12345678902', GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular'),
       ('12345678911', '12345678902', GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular'),
       ('12345678912', '12345678902', GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular'),
       ('12345678913', '12345678902', GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular'),
       ('12345678914', '12345678902', GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular');

-- Approve member registration request and provide initial membership
CREATE OR ALTER PROCEDURE ApproveMemberRegistrationRequest(
    @MemberSSN VARCHAR(11),
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insert into Member table
        INSERT INTO Member (Member_SSN, Gender, Gmail, First_Name, Last_Name, Height, Weight)
        SELECT Member_SSN, Gender, Gmail, First_Name, Last_Name, Height, Weight
        FROM Member_Registration
        WHERE Member_SSN = @MemberSSN AND GYM_SSN = @GymSSN;

        -- Insert into MemberjoinGym table
        INSERT INTO MemberjoinGym (GYM_SSN, Member_SSN)
        VALUES (@GymSSN, @MemberSSN);

        -- Insert initial membership
        INSERT INTO MemberHasGymMembership (Member_SSN, GYM_SSN, Start_Date, End_Date, type_membership)
        VALUES (@MemberSSN, @GymSSN, GETDATE(), DATEADD(month, 1, GETDATE()), 'Regular');

        -- Delete from Member_Registration
        DELETE FROM Member_Registration WHERE Member_SSN = @MemberSSN AND GYM_SSN = @GymSSN;

        COMMIT TRANSACTION;
        
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 0 AS status; -- Indicate failure
    END CATCH
END;


EXEC ApproveMemberRegistrationRequest '12345612325', '12345678902'


-- Approve trainer request by gym
CREATE OR ALTER PROCEDURE ApproveTrainerRegistrationRequest(
    @TrainerSSN VARCHAR(11),
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Insert into Trainer table
        INSERT INTO Trainer (Trainer_SSN, Gender, Gmail, First_Name, Last_Name, YoE, Password)
        SELECT Trainer_SSN, Gender, Gmail, First_Name, Last_Name, YoE, Password
        FROM Trainer_Registration
        WHERE Trainer_SSN = @TrainerSSN;

        -- Insert into GymApprovesTrainer table
        INSERT INTO TrainerWorksGym (Trainer_SSN, GYM_SSN)
        VALUES (@TrainerSSN, @GymSSN);

        -- Delete from Trainer_Registration
        DELETE FROM Trainer_Registration WHERE Trainer_SSN = @TrainerSSN;

        COMMIT TRANSACTION;
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 0 AS status, ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage; -- Indicate failure
    END CATCH
END;


@TrainerSSN = 'T_002'
@GymSSN = '12345678902'
EXEC ApproveTrainerRegistrationRequest 'T_215', '12345678902'

-- reject member request by gym
CREATE OR ALTER PROCEDURE RejectMemberRegistrationRequest(
    @MemberSSN VARCHAR(11),
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Member_Registration
        WHERE Member_SSN = @MemberSSN AND GYM_SSN = @GymSSN;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC RejectMemberRegistrationRequest '12345678910', '12345678902'

-- reject trainer request by gym

CREATE OR ALTER PROCEDURE RejectTrainerRegistrationRequest(
    @TrainerSSN VARCHAR(11),
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Trainer_Registration
        WHERE Trainer_SSN = @TrainerSSN AND GYM_SSN = @GymSSN;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC RejectTrainerRegistrationRequest 'T_216', '12345678902'

-- gym owner create gym registration request 
CREATE OR ALTER PROCEDURE CreateGymRegistrationRequest(
    @GymSSN VARCHAR(11),
    @Name VARCHAR(50),
    @Gmail VARCHAR(100),
    @Location VARCHAR(50),
    @OwnerSSN VARCHAR(11)
)
AS
BEGIN
    -- Check if the Gym SSN already exists in the database
    IF EXISTS (SELECT 1 FROM Gym_Registration WHERE GYM_SSN = @GymSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Gym WHERE GYM_SSN = @GymSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Gym WHERE Gmail = @Gmail)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (Gmail already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Gym_Registration WHERE Gmail = @Gmail)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (Gmail already exists)
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Gym_Registration (GYM_SSN, Name, Gmail, Location, GO_SSN)
        VALUES (@GymSSN, @Name, @Gmail, @Location, @OwnerSSN);
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status; -- Indicate failure (insertion error)
    END CATCH
END;

-- prtotype
EXEC CreateGymRegistrationRequest @GymSSN = '12345678903', @Name = 'Gym 3', @Gmail = 'v', @Location = 'v', @OwnerSSN = 'GO_001'
-- dummy data 10 requets using CreateGymRegistrationRequest
EXEC CreateGymRegistrationRequest '12345678904', 'Gym 4', 'temp', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678905', 'Gym 5', 'temp2', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678906', 'Gym 6', 'temp3', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678907', 'Gym 7', 'temp4', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678908', 'Gym 8', 'temp5', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678909', 'Gym 9', 'temp6', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678910', 'Gym 10', 'temp7', 'temp', 'GO_001'
EXEC CreateGymRegistrationRequest '12445678911', 'Gym 11', 'temp8', 'temp', 'GO_001'


-- return all gym registration requests
CREATE OR ALTER FUNCTION GetGymRegistrationRequests()
RETURNS TABLE
AS
RETURN
(
    SELECT GR.GYM_SSN, GR.Name, GR.Gmail, GR.Location
    FROM Gym_Registration GR
);

SELECT * FROM GetGymRegistrationRequests()

-- approve gym registration request

CREATE OR ALTER PROCEDURE ApproveGymRegistrationRequest(
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRANSACTION; -- Add this line

    BEGIN TRY
        -- check if gym is prenent is registration table
        IF NOT EXISTS (SELECT 1 FROM Gym_Registration WHERE GYM_SSN = @GymSSN)
        BEGIN
            -- THROUGH ERROR
            RAISERROR('Invalid Customer', 16, 1)
        END

        -- Insert into Gym table
        INSERT INTO Gym (GYM_SSN, Name, Gmail, Location, GO_SSN)
        SELECT GYM_SSN, Name, Gmail, Location, GO_SSN
        FROM Gym_Registration
        WHERE GYM_SSN = @GymSSN;

        -- Delete from Gym_Registration
        DELETE FROM Gym_Registration WHERE GYM_SSN = @GymSSN;

        COMMIT TRANSACTION;
        SELECT 1 AS status; 
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; 
        SELECT 0 AS status; -- Indicate failure
    END CATCH
END;

EXEC ApproveGymRegistrationRequest '12445678906'

-- reject gym registration request
CREATE OR ALTER PROCEDURE RejectGymRegistrationRequest(
    @GymSSN VARCHAR(11)
)
AS
BEGIN
    BEGIN TRY
        DELETE FROM Gym_Registration
        WHERE GYM_SSN = @GymSSN;
        SELECT 1;
    END TRY
    BEGIN CATCH
        SELECT 0;
    END CATCH
END;

EXEC RejectGymRegistrationRequest '12445678907'

--------------------------------------------------------------------------------------------------------
--                                          Admin Reports                                             --
--------------------------------------------------------------------------------------------------------

CREATE OR ALTER FUNCTION GetGymsWithLatestMembership()
RETURNS TABLE
AS
RETURN
(
    SELECT G.GYM_SSN, G.Name AS Gym_Name, G.Location, 
           M.Package, M.Join_Date, M.End_Date,
           CASE
               WHEN M.End_Date IS NULL THEN 'No'
               WHEN M.End_Date >= GETDATE() THEN 'Active'
               ELSE 'Expired'
           END AS Membership_Status
    FROM Gym G
    LEFT JOIN (
        SELECT *
        FROM (
            SELECT *, ROW_NUMBER() OVER (PARTITION BY GYM_SSN ORDER BY End_Date DESC) AS rn
            FROM Membership
        ) AS M
        WHERE rn = 1
    ) AS M ON G.GYM_SSN = M.GYM_SSN
);

SELECT * FROM GetGymsWithLatestMembership()
SELECT * FROM GetGymsWithLatestMembership() WHERE Membership_Status LIKE '%%' AND (Package LIKE '%%' OR Package IS NULL);


CREATE OR ALTER FUNCTION GetGymsWithMemberships()
RETURNS TABLE
AS
RETURN
(
    SELECT G.GYM_SSN, G.Name AS Gym_Name, G.Location, 
           M.Package, M.Join_Date, M.End_Date,
           CASE
               WHEN M.End_Date IS NULL THEN 'No'
               WHEN M.End_Date >= GETDATE() THEN 'Active'
               ELSE 'Expired'
           END AS Membership_Status
    FROM Gym G
    LEFT JOIN Membership M ON G.GYM_SSN = M.GYM_SSN
);


SELECT * FROM GetGymsWithMemberships()

INSERT INTO Membership (Membership_ID, GYM_SSN, Package, Join_Date, End_Date)
VALUES 
(11, 'GYM_001', 'Gold', '2021-02-01', '2022-11-30'),
(12, 'GYM_001', 'Silver', '2022-02-01', '2023-11-30'),
(13, 'GYM_001', 'Silver', '2023-02-01', '2024-11-30');

DELETE FROM Membership WHERE Membership_ID = 13

-- revoke gym membership by admin using gym id by adding entry in membership take gym id as refrence
CREATE OR ALTER PROCEDURE RevokeGymMembershipByAdmin
    @GymSSN VARCHAR(11),
    @Package VARCHAR(50) -- Assuming you want to specify the package for the new membership
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if the gym exists
        IF NOT EXISTS (SELECT 1 FROM Gym WHERE GYM_SSN = @GymSSN)
        BEGIN
            RAISERROR('Invalid Gym', 16, 1);
        END;

        -- Check if the gym already has membership
        IF EXISTS (SELECT 1 FROM Membership WHERE GYM_SSN = @GymSSN)
        BEGIN
            RAISERROR('Gym already has Membership', 16, 1);
        END;

        -- Get the current date
        DECLARE @JoinDate DATE = GETDATE();

        -- Calculate the End_Date based on the package duration
        DECLARE @EndDate DATE;
        IF @Package = 'Silver'
            SET @EndDate = DATEADD(MONTH, 3, @JoinDate); 
        ELSE IF @Package = 'Gold'
            SET @EndDate = DATEADD(MONTH, 12, @JoinDate); 
        ELSE IF @Package = 'Platinum'
            SET @EndDate = DATEADD(MONTH, 18, @JoinDate); 
        ELSE IF @Package = 'Bronze'
            SET @EndDate = DATEADD(MONTH, 6, @JoinDate);
        ELSE
            BEGIN
            RAISERROR('Invalid Package', 16, 1);
        END;

        -- Insert new membership
        INSERT INTO Membership (Membership_ID, GYM_SSN, Package, Join_Date, End_Date)
        VALUES ((SELECT MAX(Membership_id) FROM Membership) + 1, @GymSSN, @Package, @JoinDate, @EndDate);

        COMMIT TRANSACTION;
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 0 AS status, ERROR_MESSAGE();
    END CATCH
END;


EXEC RevokeGymMembershipByAdmin '12345678902', 'Silver'

-- delete gym by admin using gym id
-- first delete all the data from membership table
-- then delete from gym table
CREATE OR ALTER PROCEDURE DeleteGymByAdmin
    @GymSSN VARCHAR(11)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if the gym exists
        IF NOT EXISTS (SELECT 1 FROM Gym WHERE GYM_SSN = @GymSSN)
        BEGIN
            RAISERROR('Invalid Gym', 16, 1);
        END;

        -- Delete from TrainerWorksGym
        DELETE FROM TrainerWorksGym WHERE GYM_SSN = @GymSSN;

        -- Delete all memberships of the gym
        DELETE FROM Membership WHERE GYM_SSN = @GymSSN;

        -- Delete from MemberHasGymMembership
        DELETE FROM MemberHasGymMembership WHERE GYM_SSN = @GymSSN;

        -- Delete the gym
        DELETE FROM Gym WHERE GYM_SSN = @GymSSN;

        COMMIT TRANSACTION;
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT 0 AS status, ERROR_MESSAGE();
    END CATCH
END;



EXEC DeleteGymByAdmin '12344321'

--------------------------------------------------------------------------------------------------------
--                                          Weekly Plan                                               --
--------------------------------------------------------------------------------------------------------


-- Insert Weekly Plan for a member FUNCTION
CREATE OR ALTER PROCEDURE InsertWeeklyPlan
    @Member_SSN VARCHAR(11),
    @Day VARCHAR(10),
    @Workout_ID INT = NULL,
    @Diet_Plan_ID INT = NULL
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM Member WHERE Member_SSN = @Member_SSN)
        BEGIN
            RAISERROR('Invalid Member', 16, 1);
        END;

        IF @Workout_ID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Workout_Plan WHERE Workout_ID = @Workout_ID)
        BEGIN
            RAISERROR('Invalid Workout Plan', 16, 1);
        END;

        IF @Diet_Plan_ID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Diet_Plan WHERE Diet_Plan_ID = @Diet_Plan_ID)
        BEGIN
            RAISERROR('Invalid Diet Plan', 16, 1);
        END;

        IF EXISTS (SELECT 1 FROM WeeklyPlan WHERE Member_SSN = @Member_SSN AND day = @Day)
        BEGIN
            -- If a plan already exists for the specified day, replace it
            UPDATE WeeklyPlan
            SET Workout_ID = ISNULL(@Workout_ID, Workout_ID),
                Diet_Plan_ID = ISNULL(@Diet_Plan_ID, Diet_Plan_ID)
            WHERE Member_SSN = @Member_SSN AND day = @Day;
        END
        ELSE
        BEGIN
            -- Insert a new plan if none exists for the specified day
            INSERT INTO WeeklyPlan (Member_SSN, day, Workout_ID, Diet_Plan_ID)
            VALUES (@Member_SSN, @Day, @Workout_ID, @Diet_Plan_ID);
        END

        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status, ERROR_MESSAGE();
    END CATCH
END;


-- Dummy Data for meberSSN 11111111111
EXEC InsertWeeklyPlan '11111111111', 'monday', 1, 1
EXEC InsertWeeklyPlan '11111111111', 'tuesday', 2, 2
EXEC InsertWeeklyPlan '11111111111', 'wednesday', 5, NULL
EXEC InsertWeeklyPlan '11111111111', 'thursday', 4, 4
EXEC InsertWeeklyPlan '11111111111', 'friday', 5, 5
EXEC InsertWeeklyPlan '11111111111', 'saturday', 6, 6
EXEC InsertWeeklyPlan '11111111111', 'sunday', 7, 7

-- get weekly plan for a member
CREATE OR ALTER FUNCTION GetWeeklyPlanForMember
    (@Member_SSN VARCHAR(11))
RETURNS TABLE
AS
RETURN
(
    SELECT WP.Member_SSN, WP.day, WP.Workout_ID, WP.Diet_Plan_ID, 
           W.Name AS workout_name, D.DietPlan_Name
    FROM WeeklyPlan WP
    JOIN Workout_Plan W ON WP.Workout_ID = W.Workout_ID
    JOIN Diet_Plan D ON WP.Diet_Plan_ID = D.Diet_Plan_ID
    WHERE WP.Member_SSN = @Member_SSN
);

SELECT * FROM GetWeeklyPlanForMember('11111111111')

-- return all exersise in workout plan along with sets and reps by specifc user and specific day
CREATE OR ALTER FUNCTION GetExercisesInWorkoutPlan
    (@Member_SSN VARCHAR(11), @Day VARCHAR(10))
RETURNS TABLE
AS
RETURN
(
    SELECT W.Workout_ID, W.Name AS Workout_Name, E.Equipment_ID, E.Name AS Exercise_Name, WUE.Sets, WUE.Reps
    FROM WeeklyPlan WP
    JOIN Workout_Plan W ON WP.Workout_ID = W.Workout_ID
    JOIN WorkoutUsesEquipment WUE ON WUE.Workout_ID = W.Workout_ID
    JOIN Equipment E ON WUE.Equipment_ID = E.Equipment_ID
    WHERE WP.Member_SSN = @Member_SSN AND WP.day = @Day
);

SELECT * FROM GetExercisesInWorkoutPlan('11111111111', 'sunday')

INSERT INTO WorkoutUsesEquipment (Workout_ID, Equipment_ID, Sets, Reps)
VALUES 
(1, 2, 5, 2);

-- return all dets in deit plan along with fats and cals by specifc user and specific day
CREATE OR ALTER FUNCTION GetDietInDietPlan
    (@Member_SSN VARCHAR(11), @Day VARCHAR(10))
RETURNS TABLE
AS
RETURN
(
    SELECT DP.Diet_Plan_ID, DP.DietPlan_Name, DU.Diet_ID, D.deit_name AS Diet_Name, DU.Quantity, D.Calories, D.Fats, D.Carbs, D.Proteins
    FROM WeeklyPlan WP
    JOIN Diet_Plan DP ON WP.Diet_Plan_ID = DP.Diet_Plan_ID
    JOIN DietPlanUsesDiet DU ON DU.Diet_Plan_ID = DP.Diet_Plan_ID
    JOIN Diet D ON DU.Diet_ID = D.Diet_ID
    WHERE WP.Member_SSN = @Member_SSN AND WP.day = @Day
);


SELECT * FROM GetDietInDietPlan('11111111111', 'sunday')

--------------------------------------------------------------------------------------------------------
--                                             Trigers                                                --
--------------------------------------------------------------------------------------------------------
-- Crate trigger when any thing is added or removed or modified in all table
--   Member;
CREATE OR ALTER TRIGGER MemberChangeTrigger
ON Member
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Member', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Member', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Member', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   Trainer;
CREATE OR ALTER TRIGGER TrainerChangeTrigger
ON Trainer
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Trainer', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Trainer', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Trainer', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   Gym_Owner;
CREATE OR ALTER TRIGGER GymOwnerChangeTrigger
ON Gym_Owner
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Owner', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Owner', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Owner', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   Gym;
CREATE OR ALTER TRIGGER GymChangeTrigger
ON Gym
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   Membership;
CREATE OR ALTER TRIGGER MembershipChangeTrigger
ON Membership
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Membership', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Membership', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Membership', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;

--   Member_Registration;
CREATE OR ALTER TRIGGER MemberRegistrationChangeTrigger
ON Member_Registration
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Member_Registration', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Member_Registration', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Member_Registration', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   MemberjoinGym;
CREATE OR ALTER TRIGGER MemberjoinGymChangeTrigger
ON MemberjoinGym
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('MemberjoinGym', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('MemberjoinGym', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('MemberjoinGym', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;


--   Trainer_Registration;
CREATE OR ALTER TRIGGER TrainerRegistrationChangeTrigger
ON Trainer_Registration
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Trainer_Registration', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Trainer_Registration', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Trainer_Registration', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   Gym_Owner_Registration;
CREATE OR ALTER TRIGGER GymOwnerRegistrationChangeTrigger
ON Gym_Owner_Registration
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Owner_Registration', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Owner_Registration', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Owner_Registration', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   Gym_Registration;
CREATE OR ALTER TRIGGER GymRegistrationChangeTrigger   
ON Gym_Registration
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Registration', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Registration', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('Gym_Registration', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;
--   TrainerWorksGym;
CREATE OR ALTER TRIGGER TrainerWorksGymChangeTrigger
ON TrainerWorksGym
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('TrainerWorksGym', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('TrainerWorksGym', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('TrainerWorksGym', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;

CREATE OR ALTER TRIGGER TrainerAvailabilityChangeTrigger
ON TrainerAvailability
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    -- Check if any rows were inserted
    IF EXISTS (SELECT * FROM inserted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('TrainerAvailability', 'INSERT', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were deleted
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('TrainerAvailability', 'DELETE', (SELECT CAST((SELECT * FROM deleted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END

    -- Check if any rows were updated
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO ChangeLog (TableName, ActionPerformed, ChangedData)
        VALUES ('TrainerAvailability', 'UPDATE', (SELECT CAST((SELECT * FROM inserted FOR JSON AUTO) AS NVARCHAR(MAX))));
    END
END;

--------------------------------------------------------------------------------------------------------
--                                            Trainer home                                            --
--------------------------------------------------------------------------------------------------------


CREATE OR ALTER PROCEDURE AddTrainerAvailability
    @date DATE,
    @start_time TIME,
    @end_time TIME,
    @Trainer_SSN VARCHAR(11)
AS
BEGIN
    BEGIN TRY
        -- Check if Trainer_SSN exists in the Trainer table
        IF NOT EXISTS (SELECT 1 FROM Trainer WHERE Trainer_SSN = @Trainer_SSN)
        BEGIN
            RAISERROR('Invalid Trainer', 16, 1);
        END;

        -- Check for overlapping availability
        IF EXISTS (
            SELECT 1
            FROM TrainerAvailability
            WHERE Trainer_SSN = @Trainer_SSN
            AND date = @date
            AND ((start_time <= @end_time AND end_time >= @start_time) OR
                 (start_time >= @start_time AND end_time <= @end_time))
        )
        BEGIN
            -- Overlapping availability found, update existing record
            UPDATE TrainerAvailability
            SET start_time = CASE WHEN start_time < @start_time THEN start_time ELSE @start_time END,
                end_time = CASE WHEN end_time > @end_time THEN end_time ELSE @end_time END
            WHERE Trainer_SSN = @Trainer_SSN
            AND date = @date
            AND ((start_time <= @end_time AND end_time >= @start_time) OR
                 (start_time >= @start_time AND end_time <= @end_time));

            SELECT 2 AS status; -- Indicate that existing availability was updated
        END
        ELSE
        BEGIN
            -- No overlapping availability, insert new record
            INSERT INTO TrainerAvailability (date, start_time, end_time, Trainer_SSN)
            VALUES (@date, @start_time, @end_time, @Trainer_SSN);

            SELECT 1 AS status; -- Indicate success
        END
    END TRY
    BEGIN CATCH
        SELECT 0 AS status, ERROR_MESSAGE(); -- Indicate failure and return error message
    END CATCH
END;


-- Add availability for a trainer
EXEC AddTrainerAvailability '2024-05-20', '09:00:00', '12:00:00', 'T_001';
EXEC AddTrainerAvailability '2024-05-20', '12:00:00', '16:00:00', 'T_001';
EXEC AddTrainerAvailability '2024-05-21', '09:00:00', '12:00:00', 'T_001';
EXEC AddTrainerAvailability '2024-05-21', '14:00:00', '17:00:00', 'T_001';

SELECT * FROM TrainerAvailability;

-- return all trainers at specific date
CREATE OR ALTER FUNCTION GetTrainersAtDate
    (@date DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT T.Trainer_SSN, T.First_Name, T.Last_Name, TA.start_time, TA.end_time
    FROM Trainer T
    JOIN TrainerAvailability TA ON T.Trainer_SSN = TA.Trainer_SSN
    WHERE TA.date = @date
);

SELECT * FROM GetTrainersAtDate('2024-05-20');

-- book trainer by member
CREATE OR ALTER PROCEDURE BookTrainer
    @Member_SSN VARCHAR(11),
    @Trainer_SSN VARCHAR(11),
    @date DATE,
    @start_time TIME,
    @end_time TIME
AS
BEGIN
    BEGIN TRY
        -- Check if Member_SSN exists in the Member table
        IF NOT EXISTS (SELECT 1 FROM Member WHERE Member_SSN = @Member_SSN)
        BEGIN
            RAISERROR('Invalid Member', 16, 1);
        END;

        -- Check if Trainer_SSN exists in the Trainer table
        IF NOT EXISTS (SELECT 1 FROM Trainer WHERE Trainer_SSN = @Trainer_SSN)
        BEGIN
            RAISERROR('Invalid Trainer', 16, 1);
        END;

        -- Check if Trainer is available at the specified date and time
        IF NOT EXISTS (
            SELECT 1
            FROM TrainerAvailability
            WHERE Trainer_SSN = @Trainer_SSN
            AND date = @date
            AND start_time <= @start_time
            AND end_time >= @end_time
        )
        BEGIN
            RAISERROR('Trainer is not available at the specified date and time', 16, 1);
        END;

        -- Check if the Trainer is already booked by the Member at the specified date and time
        IF EXISTS (
            SELECT 1
            FROM MemberTrainerSession
            WHERE Trainer_SSN = @Trainer_SSN
            AND date = @date
            AND ((start_time <= @end_time AND end_time >= @start_time) OR
                 (start_time >= @start_time AND end_time <= @end_time))
        )
        BEGIN
            RAISERROR('Trainer is already booked at the specified date and time', 16, 1);
        END;

        -- Book the Trainer
        INSERT INTO MemberTrainerSession (Member_SSN, Trainer_SSN, date, start_time, end_time, duration)
        VALUES (@Member_SSN, @Trainer_SSN, @date, @start_time, @end_time, DATEDIFF(MINUTE, @start_time, @end_time));

        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status, ERROR_MESSAGE(); -- Indicate failure and return error message
    END CATCH
END;


-- example booking
EXEC BookTrainer '11111111111', 'T_001', '2024-05-20', '09:00:00', '10:00:00';

SELECT * FROM TrainerBooking;