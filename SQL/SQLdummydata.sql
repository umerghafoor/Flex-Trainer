USE FlexTrainer2;


SELECT * FROM Member;
SELECT * FROM Trainer;
SELECT * FROM Gym_Owner;
SELECT * FROM Gym;
SELECT * FROM Membership;

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

SELECT * FROM MemberHasGymMembership;
SELECT * FROM WeeklyPlan;

SELECT * FROM ChangeLog;

SELECT * FROM GymLog;

-- Insert dummy data into Member table
INSERT INTO Member (Member_SSN, Gender, Gmail, Password, First_Name, Last_Name, Height, Weight)
VALUES 
('11111111111', 'Male', '123', '123', 'John', 'Doe', 180.0, 75.0),
('22222222222', 'Female', 'member2@gmail.com', 'password2', 'Jane', 'Smith', 165.0, 60.0),
('33333333333', 'Male', 'member3@gmail.com', 'password3', 'Michael', 'Johnson', 175.0, 80.0),
('44444444444', 'Female', 'member4@gmail.com', 'password4', 'Emily', 'Brown', 160.0, 55.0),
('55555555555', 'Male', 'member5@gmail.com', 'password5', 'David', 'Wilson', 170.0, 70.0),
('66666666666', 'Female', 'member6@gmail.com', 'password6', 'Jessica', 'Martinez', 155.0, 50.0),
('77777777777', 'Male', 'member7@gmail.com', 'password7', 'Daniel', 'Anderson', 185.0, 85.0),
('88888888888', 'Female', 'member8@gmail.com', 'password8', 'Olivia', 'Taylor', 170.0, 65.0),
('99999999999', 'Male', 'member9@gmail.com', 'password9', 'James', 'Thomas', 175.0, 75.0),
('10101010101', 'Female', 'member10@gmail.com', 'password10', 'Sophia', 'White', 160.0, 60.0);

-- Insert dummy data into Trainer table
INSERT INTO Trainer (Trainer_SSN, Gender, Gmail, Password, First_Name, Last_Name, YoE)
VALUES 
('T_001', 'Male', '123', '123', 'Trainer', 'One', 5.0),
('T_002', 'Female', 'trainer2@gmail.com', 'password2', 'Trainer', 'Two', 3.0),
('T_003', 'Male', 'trainer3@gmail.com', 'password3', 'Trainer', 'Three', 2.0),
('T_004', 'Female', 'trainer4@gmail.com', 'password4', 'Trainer', 'Four', 4.0),
('T_005', 'Male', 'trainer5@gmail.com', 'password5', 'Trainer', 'Five', 6.0),
('T_006', 'Female', 'trainer6@gmail.com', 'password6', 'Trainer', 'Six', 1.0),
('T_007', 'Male', 'trainer7@gmail.com', 'password7', 'Trainer', 'Seven', 7.0),
('T_008', 'Female', 'trainer8@gmail.com', 'password8', 'Trainer', 'Eight', 2.0),
('T_009', 'Male', 'trainer9@gmail.com', 'password9', 'Trainer', 'Nine', 4.0),
('T_010', 'Female', 'trainer10@gmail.com', 'password10', 'Trainer', 'Ten', 3.0);

-- Insert dummy data into Gym_Owner table
INSERT INTO Gym_Owner (GO_SSN, Gender, Gmail, Password, First_Name, Last_Name)
VALUES 
('GO_001', 'Male', '123', '123', 'Owner', 'One'),
('GO_002', 'Female', 'owner2@gmail.com', 'password2', 'Owner', 'Two'),
('GO_003', 'Male', 'owner3@gmail.com', 'password3', 'Owner', 'Three'),
('GO_004', 'Female', 'owner4@gmail.com', 'password4', 'Owner', 'Four'),
('GO_005', 'Male', 'owner5@gmail.com', 'password5', 'Owner', 'Five'),
('GO_006', 'Female', 'owner6@gmail.com', 'password6', 'Owner', 'Six'),
('GO_007', 'Male', 'owner7@gmail.com', 'password7', 'Owner', 'Seven'),
('GO_008', 'Female', 'owner8@gmail.com', 'password8', 'Owner', 'Eight'),
('GO_009', 'Male', 'owner9@gmail.com', 'password9', 'Owner', 'Nine'),
('GO_010', 'Female', 'owner10@gmail.com', 'password10', 'Owner', 'Ten');

-- Insert dummy data into Gym table
INSERT INTO Gym (GYM_SSN, Name, Location, Gmail, GO_SSN)
VALUES 
('GYM_001', 'Gym 1', 'Location 1', 'gym1@gmail.com', 'GO_001'),
('GYM_002', 'Gym 2', 'Location 2', 'gym2@gmail.com', 'GO_002'),
('GYM_003', 'Gym 3', 'Location 3', 'gym3@gmail.com', 'GO_003'),
('GYM_004', 'Gym 4', 'Location 4', 'gym4@gmail.com', 'GO_004'),
('GYM_005', 'Gym 5', 'Location 5', 'gym5@gmail.com', 'GO_005'),
('GYM_006', 'Gym 6', 'Location 6', 'gym6@gmail.com', 'GO_006'),
('GYM_007', 'Gym 7', 'Location 7', 'gym7@gmail.com', 'GO_007'),
('GYM_008', 'Gym 8', 'Location 8', 'gym8@gmail.com', 'GO_008'),
('GYM_009', 'Gym 9', 'Location 9', 'gym9@gmail.com', 'GO_009'),
('GYM_010', 'Gym 10', 'Location 10', 'gym10@gmail.com', 'GO_010');

-- Insert dummy data into TrainerWorksGym table
INSERT INTO TrainerWorksGym (GYM_SSN, Trainer_SSN)
VALUES 
('GYM_001', 'T_001'),
('GYM_002', 'T_002'),
('GYM_003', 'T_003'),
('GYM_004', 'T_004'),
('GYM_005', 'T_005'),
('GYM_006', 'T_006'),
('GYM_007', 'T_007'),
('GYM_008', 'T_008'),
('GYM_009', 'T_009'),
('GYM_010', 'T_010');

-- Insert dummy data into Admin table
INSERT INTO Admin (SSN, Name, Gmail, Password)
VALUES 
('AD_001', 'Admin 1', 'admin1@gmail.com', 'password1'),
('AD_002', 'Admin 2', 'admin2@gmail.com', 'password2'),
('AD_003', 'Admin 3', 'admin3@gmail.com', 'password3'),
('AD_004', 'Admin 4', 'admin4@gmail.com', 'password4'),
('AD_005', 'Admin 5', 'admin5@gmail.com', 'password5'),
('AD_006', 'Admin 6', 'admin6@gmail.com', 'password6'),
('AD_007', 'Admin 7', 'admin7@gmail.com', 'password7'),
('AD_008', 'Admin 8', 'admin8@gmail.com', 'password8'),
('AD_009', 'Admin 9', 'admin9@gmail.com', 'password9'),
('AD_010', 'Admin 10', 'admin10@gmail.com', 'password10');

-- Insert dummy data into Equipment table
INSERT INTO Equipment (Equipment_ID, Category, Name)
VALUES 
(1, 'Cardio', 'Treadmill'),
(2, 'Strength', 'Dumbbells'),
(3, 'Cardio', 'Stationary Bike'),
(4, 'Strength', 'Barbell'),
(5, 'Cardio', 'Elliptical'),
(6, 'Strength', 'Bench Press'),
(7, 'Cardio', 'Rowing Machine'),
(8, 'Strength', 'Leg Press'),
(9, 'Cardio', 'Stair Climber'),
(10, 'Strength', 'Cable Machine');

-- Insert dummy data into Diet table
INSERT INTO Diet (Diet_ID, deit_name, Fats, Carbs, Proteins, Calories)
VALUES 
(1, 'Diet 1', 10, 20, 30, 250),
(2, 'Diet 2', 15, 25, 35, 300),
(3, 'Diet 3', 20, 30, 40, 350),
(4, 'Diet 4', 25, 35, 45, 400),
(5, 'Diet 5', 30, 40, 50, 450),
(6, 'Diet 6', 35, 45, 55, 500),
(7, 'Diet 7', 40, 50, 60, 550),
(8, 'Diet 8', 45, 55, 65, 600),
(9, 'Diet 9', 50, 60, 70, 650),
(10, 'Diet 10', 55, 65, 75, 700);

-- Insert dummy data into Workout_Log table
INSERT INTO Workout_Log (Date, Time, Daily_Goal_Percentage, Member_SSN)
VALUES 
('2024-05-01', '08:00:00', 80.0, '11111111111'),
('2024-05-02', '09:00:00', 75.0, '22222222222'),
('2024-05-03', '10:00:00', 85.0, '33333333333'),
('2024-05-04', '11:00:00', 90.0, '44444444444'),
('2024-05-05', '12:00:00', 95.0, '55555555555'),
('2024-05-06', '13:00:00', 80.0, '66666666666'),
('2024-05-07', '14:00:00', 75.0, '77777777777'),
('2024-05-08', '15:00:00', 85.0, '88888888888'),
('2024-05-09', '16:00:00', 90.0, '99999999999'),
('2024-05-10', '17:00:00', 95.0, '10101010101');

-- Insert dummy data into Diet_Log table
INSERT INTO Diet_Log (Weight, Meal_Name, Calories, Fats, Carbs, Proteins, date, time, Member_SSN)
VALUES 
(70.0, 'Breakfast', 300, 10, 20, 30, '2024-05-01', '08:00:00', '11111111111'),
(65.0, 'Lunch', 350, 15, 25, 35, '2024-05-02', '09:00:00', '22222222222'),
(80.0, 'Dinner', 400, 20, 30, 40, '2024-05-03', '10:00:00', '33333333333'),
(55.0, 'Snack', 450, 25, 35, 45, '2024-05-04', '11:00:00', '44444444444'),
(75.0, 'Breakfast', 500, 30, 40, 50, '2024-05-05', '12:00:00', '55555555555'),
(70.0, 'Lunch', 550, 35, 45, 55, '2024-05-06', '13:00:00', '66666666666'),
(65.0, 'Dinner', 600, 40, 50, 60, '2024-05-07', '14:00:00', '77777777777'),
(90.0, 'Snack', 650, 45, 55, 65, '2024-05-08', '15:00:00', '88888888888'),
(85.0, 'Breakfast', 700, 50, 60, 70, '2024-05-09', '16:00:00', '99999999999'),
(80.0, 'Lunch', 750, 55, 65, 75, '2024-05-10', '17:00:00', '10101010101');


-- Insert dummy data into Membership table
INSERT INTO Membership (Membership_ID, GYM_SSN, Package, Join_Date, End_Date)
VALUES 
(1, 'GYM_001', 'Gold', '2024-01-01', '2024-12-31'),
(2, 'GYM_002', 'Silver', '2024-02-01', '2024-11-30'),
(3, 'GYM_003', 'Bronze', '2024-03-01', '2024-10-31'),
(4, 'GYM_004', 'Platinum', '2024-04-01', '2024-09-30'),
(5, 'GYM_005', 'Gold', '2024-05-01', '2024-08-31'),
(6, 'GYM_006', 'Silver', '2024-06-01', '2024-07-31'),
(7, 'GYM_007', 'Bronze', '2024-07-01', '2024-06-30'),
(8, 'GYM_008', 'Platinum', '2024-08-01', '2024-05-31'),
(9, 'GYM_009', 'Gold', '2024-09-01', '2024-04-30'),
(10, 'GYM_010', 'Silver', '2024-10-01', '2024-03-31');

-- Insert dummy data into WeeklyPlan table
INSERT INTO WeeklyPlan (Member_SSN, day, Workout_ID, Diet_Plan_ID)
VALUES 
('11111111111', 'Monday', 1, 1),
('22222222222', 'Tuesday', 2, 2),
('33333333333', 'Wednesday', 3, 3),
('44444444444', 'Thursday', 4, 4),
('55555555555', 'Friday', 5, 5),
('66666666666', 'Saturday', 6, 6),
('77777777777', 'Sunday', 7, 7),
('88888888888', 'Monday', 8, 8),
('99999999999', 'Tuesday', 9, 9),
('10101010101', 'Wednesday', 10, 10);
--------------------------------------------------------------------------------------------------------------------------------------
-- Insert dummy data into TrainerWorksGym table
INSERT INTO TrainerWorksGym (GYM_SSN, Trainer_SSN)
VALUES 
('GYM_001', 'T_001'),
('GYM_002', 'T_002'),
('GYM_003', 'T_003'),
('GYM_004', 'T_004'),
('GYM_005', 'T_005'),
('GYM_006', 'T_006'),
('GYM_007', 'T_007'),
('GYM_008', 'T_008'),
('GYM_009', 'T_009'),
('GYM_010', 'T_010');

-- Insert dummy data into MemberTrainerSession table
INSERT INTO MemberTrainerSession (Trainer_SSN, Member_SSN, date, time, duration)
VALUES 
('T_001', '11111111111', '2024-05-01', '08:00:00', 60),
('T_002', '22222222222', '2024-05-02', '09:00:00', 45),
('T_003', '33333333333', '2024-05-03', '10:00:00', 75),
('T_004', '44444444444', '2024-05-04', '11:00:00', 30),
('T_005', '55555555555', '2024-05-05', '12:00:00', 90),
('T_006', '66666666666', '2024-05-06', '13:00:00', 45),
('T_007', '77777777777', '2024-05-07', '14:00:00', 60),
('T_008', '88888888888', '2024-05-08', '15:00:00', 30),
('T_009', '99999999999', '2024-05-09', '16:00:00', 75),
('T_010', '10101010101', '2024-05-10', '17:00:00', 45);

-- Insert dummy data into MemberFeedback table
INSERT INTO MemberFeedback (Trainer_SSN, Member_SSN, COMMENT, RATING)
VALUES 
('T_001', '11111111111', 'Good session today!', 4.5),
('T_002', '22222222222', 'Could improve on pacing.', 3.0),
('T_003', '33333333333', 'Excellent guidance throughout.', 5.0),
('T_004', '44444444444', 'Need more variety in workouts.', 3.5),
('T_005', '55555555555', 'Really feeling the progress!', 4.8),
('T_006', '66666666666', 'Need more focus on core.', 3.2),
('T_007', '77777777777', 'Great motivation during session.', 4.7),
('T_008', '88888888888', 'Exercises felt a bit rushed.', 3.0),
('T_009', '99999999999', 'Appreciate the personalized plan.', 4.9),
('T_010', '10101010101', 'Very knowledgeable and supportive.', 5.0);

-- Insert dummy data into Workout_Plan table
INSERT INTO Workout_Plan (Workout_ID, Name, Public_Flag, Category, Target_Muscle, Total_Time, Member_SSN, Trainer_SSN)
VALUES 
(1, 'Workout 1', 1, 'Strength', 'Chest', 60, '11111111111', NULL),
(2, 'Workout 2', 0, 'Cardio', 'Legs', 45, NULL, 'T_001'),
(3, 'Workout 3', 1, 'Strength', 'Back', 75, '33333333333', NULL),
(4, 'Workout 4', 0, 'Cardio', 'Arms', 30, NULL, 'T_002'),
(5, 'Workout 5', 1, 'Strength', 'Shoulders', 90, '55555555555', NULL),
(6, 'Workout 6', 0, 'Cardio', 'Abs', 45, NULL, 'T_003'),
(7, 'Workout 7', 1, 'Strength', 'Legs', 60, '77777777777', NULL),
(8, 'Workout 8', 0, 'Cardio', 'Chest', 30, NULL, 'T_004'),
(9, 'Workout 9', 1, 'Strength', 'Arms', 75, '99999999999', NULL),
(10, 'Workout 10', 0, 'Cardio', 'Back', 45, NULL, 'T_005');
-------------------------------------------------------------------------------------------------------------------------------------------------------
-- Insert dummy data into Diet_Plan table
INSERT INTO Diet_Plan (Diet_Plan_ID, Public_Flag, DietPlan_Name, Type_Diet_Plan, Time_Of_Day, Member_SSN, Trainer_SSN)
VALUES 
(1, 1, 'Diet Plan 1', 'Keto', 'Morning', '11111111111', NULL),
(2, 0, 'Diet Plan 2', 'Vegetarian', 'Afternoon', NULL, 'T_001'),
(3, 1, 'Diet Plan 3', 'Vegan', 'Evening', '33333333333', NULL),
(4, 0, 'Diet Plan 4', 'Paleo', 'Night', NULL, 'T_002'),
(5, 1, 'Diet Plan 5', 'Low-Carb', 'Morning', '55555555555', NULL),
(6, 0, 'Diet Plan 6', 'Balanced', 'Afternoon', NULL, 'T_003'),
(7, 1, 'Diet Plan 7', 'Low-Fat', 'Evening', '77777777777', NULL),
(8, 0, 'Diet Plan 8', 'High-Protein', 'Night', NULL, 'T_004'),
(9, 1, 'Diet Plan 9', 'Low-Calorie', 'Morning', '99999999999', NULL),
(10, 0, 'Diet Plan 10', 'Intermittent Fasting', 'Afternoon', NULL, 'T_005');

INSERT INTO WorkoutUsesEquipment (Workout_ID, Equipment_ID, Sets, Reps)
VALUES 
(1, 1, 3, 12),
(2, 2, 4, 10),
(3, 3, 3, 15),
(4, 4, 5, 8),
(5, 5, 4, 12),
(6, 6, 3, 10),
(7, 7, 5, 8),
(8, 8, 4, 12),
(9, 9, 3, 10),
(10, 10, 5, 8);

-- Insert dummy data into DietPlanUsesDiet table
INSERT INTO DietPlanUsesDiet (Diet_Plan_ID, Diet_ID, Quantity)
VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10);


INSERT INTO MemberHasGymMembership (Member_SSN, GYM_SSN, Start_Date, End_Date, type_membership)
VALUES 
('11111111111', 'GYM_001', '2023-01-01', '2023-12-31', 'Gold'),
('22222222222', 'GYM_001', '2023-02-01', '2023-11-30', 'Silver'),
('33333333333', 'GYM_001', '2023-03-01', '2023-10-31', 'Bronze'),
('44444444444', 'GYM_001', '2023-04-01', '2023-09-30', 'Platinum'),
('55555555555', 'GYM_001', '2023-05-01', '2023-08-31', 'Gold'),
('66666666666', 'GYM_001', '2023-06-01', '2023-07-31', 'Silver'),
('77777777777', 'GYM_001', '2023-07-01', '2023-06-30', 'Bronze'),
('88888888888', 'GYM_001', '2023-08-01', '2023-05-31', 'Platinum'),
('99999999999', 'GYM_001', '2023-09-01', '2023-04-30', 'Gold'),
('10101010101', 'GYM_001', '2023-10-01', '2023-03-31', 'Silver');


INSERT INTO MemberHasGymMembership (Member_SSN, GYM_SSN, Start_Date, End_Date, type_membership)
VALUES 
('11111111111', 'GYM_001', '2023-12-31', '2024-12-31', 'Gold');


----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------------
BULK INSERT Gym
FROM 'D:\Users\Github\Flex-Trainer\SQL\data\Gym.csv'
WITH (
    FIELDTERMINATOR = ',',  
    ROWTERMINATOR = '\n',   
    FIRSTROW = 2 

);

SELECT * FROM Gym

-- remove rows where gender = Polygender
