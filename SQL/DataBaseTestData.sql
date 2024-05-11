
USE FlexTrainer2;

SELECT * FROM Member;
SELECT * FROM Trainer;
SELECT * FROM Gym_Owner;
SELECT * FROM Gym;
SELECT * FROM Member_Registration;
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

SELECT * FROM GetWorkoutEquipmentDetails('12345678901') 
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

-- create member registration request
CREATE OR ALTER PROCEDURE CreateMemberRegistrationRequest(
    @MemberSSN VARCHAR(11),
    @Gender VARCHAR(10),
    @Gmail VARCHAR(100),
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Height FLOAT,
    @Weight FLOAT,
    @Password VARCHAR(50)
)
AS
BEGIN
    -- Check if the Member SSN already exists in the database
    IF EXISTS (SELECT 1 FROM Member_Registration WHERE Member_SSN = @MemberSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Member WHERE Member_SSN = @MemberSSN)
    BEGIN
        SELECT 0 AS status; -- Indicate failure (SSN already exists)
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Member_Registration (Member_SSN, Gender, Gmail, First_Name, Last_Name, Height, Weight, Password)
        VALUES (@MemberSSN, @Gender, @Gmail, @FirstName, @LastName, @Height, @Weight, @Password);
        SELECT 1 AS status; -- Indicate success
    END TRY
    BEGIN CATCH
        SELECT 0 AS status; -- Indicate failure (insertion error)
    END CATCH
END;

-- create trainer registration request
CREATE OR ALTER PROCEDURE CreateTrainerRegistrationRequest(
    @TrainerSSN VARCHAR(11),
    @Gender VARCHAR(10),
    @Gmail VARCHAR(100),
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @YoE FLOAT,
    @Password VARCHAR(50)
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

    BEGIN TRY
        INSERT INTO Trainer_Registration (Trainer_SSN, Gender, Gmail, First_Name, Last_Name, YoE, Password)
        VALUES (@TrainerSSN, @Gender, @Gmail, @FirstName, @LastName, @YoE, @Password);
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


EXEC CreateMemberRegistrationRequest '11111111111', 'M', 'test@gmail.com', 'John', 'Doe', 5, 70, 'password123'
EXEC CreateTrainerRegistrationRequest 'T_002', 'M', 'trainer@gmail.com', 'Trainer', 'Trainer', 2, 'password456'
EXEC CreateGymOwnerRegistrationRequest 'GO_001', 'M', 'owner@gmail.com', 'Owner', 'Owner', 'password789'

