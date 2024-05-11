
USE FlexTrainer;
-- Inserting dummy data into the Member table
INSERT INTO Member (Member_SSN, Gender, Gmail, Password, First_Name, Last_Name, Height, Weight) 
VALUES 
('12345678901', 'Male', 'john@example.com', 'password1', 'John', 'Doe', 175.5, 70.2),
('23456789012', 'Female', 'jane@example.com', 'password2', 'Jane', 'Smith', 160.0, 55.8),
('34567890123', 'Male', 'alex@example.com', 'password3', 'Alex', 'Johnson', 180.3, 85.0),
('45678901234', 'Female', 'emily@example.com', 'password4', 'Emily', 'Brown', 165.8, 60.5),
('56789012345', 'Male', 'michael@example.com', 'password5', 'Michael', 'Lee', 172.0, 75.6),
('67890123456', 'Female', 'sarah@example.com', 'password6', 'Sarah', 'Taylor', 155.2, 50.9),
('78901234567', 'Male', 'adam@example.com', 'password7', 'Adam', 'Wilson', 178.9, 80.3),
('89012345678', 'Female', 'olivia@example.com', 'password8', 'Olivia', 'Anderson', 162.4, 58.7),
('90123456789', 'Male', 'jacob@example.com', 'password9', 'Jacob', 'Martinez', 183.6, 88.1),
('01234567890', 'Female', 'ava@example.com', 'password10', 'Ava', 'Garcia', 157.7, 53.4);

SELECT * FROM Member;
-- Inserting dummy data into the Trainer table
INSERT INTO Trainer (Trainer_SSN, Gender, Gmail, Password, First_Name, Last_Name, Weight, YoE) 
VALUES 
('1234567890T', 'Male', 'trainer1@example.com', 'password11', 'Trainer1', 'Smith', 75.5, 2),
('2345678902T', 'Female', 'trainer2@example.com', 'password12', 'Trainer2', 'Johnson', 65.0, 3),
('3456789023T', 'Male', 'trainer3@example.com', 'password13', 'Trainer3', 'Williams', 80.2, 5),
('4567890234T', 'Female', 'trainer4@example.com', 'password14', 'Trainer4', 'Brown', 70.8, 4),
('5678902345T', 'Male', 'trainer5@example.com', 'password15', 'Trainer5', 'Jones', 76.3, 6),
('6789023456T', 'Female', 'trainer6@example.com', 'password16', 'Trainer6', 'Davis', 63.7, 2),
('7890234567T', 'Male', 'trainer7@example.com', 'password17', 'Trainer7', 'Miller', 85.1, 3),
('8902345678T', 'Female', 'trainer8@example.com', 'password18', 'Trainer8', 'Wilson', 68.9, 1),
('9023456789T', 'Male', 'trainer9@example.com', 'password19', 'Trainer9', 'Moore', 82.5, 4),
('0234567890T', 'Female', 'trainer10@example.com', 'password20', 'Trainer10', 'Taylor', 71.4, 2);

SELECT * FROM Trainer;

-- Inserting dummy data into the Gym_Owner table
INSERT INTO Gym_Owner (GO_SSN, Gender, Gmail, Password, First_Name, Last_Name) 
VALUES 
('1234567890O', 'Male', 'owner1@example.com', 'password21', 'Owner1', 'Smith'),
('2345678902O', 'Female', 'owner2@example.com', 'password22', 'Owner2', 'Johnson'),
('3456789023O', 'Male', 'owner3@example.com', 'password23', 'Owner3', 'Williams'),
('4567890234O', 'Female', 'owner4@example.com', 'password24', 'Owner4', 'Brown'),
('5678902345O', 'Male', 'owner5@example.com', 'password25', 'Owner5', 'Jones'),
('6789023456O', 'Female', 'owner6@example.com', 'password26', 'Owner6', 'Davis'),
('7890234567O', 'Male', 'owner7@example.com', 'password27', 'Owner7', 'Miller'),
('8902345678O', 'Female', 'owner8@example.com', 'password28', 'Owner8', 'Wilson'),
('9023456789O', 'Male', 'owner9@example.com', 'password29', 'Owner9', 'Moore'),
('0234567890O', 'Female', 'owner10@example.com', 'password30', 'Owner10', 'Taylor');

SELECT * FROM Gym_Owner;

-- Inserting dummy data into the Gym table
INSERT INTO Gym (GYM_SSN, Name, Location, Gmail, GO_SSN) 
VALUES 
('1234567GYM', 'Gym1', 'Location1', 'gym1@example.com', '1234567890O'),
('2345679GYM', 'Gym2', 'Location2', 'gym2@example.com', '2345678902O'),
('3456790GYM', 'Gym3', 'Location3', 'gym3@example.com', '3456789023O'),
('4567901GYM', 'Gym4', 'Location4', 'gym4@example.com', '4567890234O'),
('5679012GYM', 'Gym5', 'Location5', 'gym5@example.com', '5678902345O'),
('6790123GYM', 'Gym6', 'Location6', 'gym6@example.com', '6789023456O'),
('7901234GYM', 'Gym7', 'Location7', 'gym7@example.com', '7890234567O'),
('9012345GYM', 'Gym8', 'Location8', 'gym8@example.com', '8902345678O'),
('9012356GYM', 'Gym9', 'Location9', 'gym9@example.com', '9023456789O'),
('0123567GYM', 'Gym10', 'Location10', 'gym10@example.com', '1234567890O');

SELECT * FROM Gym;

-- Inserting dummy data into the TrainerWorksGym table
INSERT INTO TrainerWorksGym (GYM_SSN, Trainer_SSN) 
VALUES 
('12345678GYM', '1234567890T'),
('23456789GYM', '2345678902T'),
('34567890GYM', '3456789023T'),
('45678901GYM', '4567890234T'),
('56789012GYM', '5678902345T'),
('67890123GYM', '6789023456T'),
('78901234GYM', '7890234567T'),
('89012345GYM', '8902345678T'),
('90123456GYM', '9023456789T'),
('01234567GYM', '0234567890T');

SELECT * FROM TrainerWorksGym;

-- Inserting dummy data into the MemberTrainerSession table
INSERT INTO MemberTrainerSession (Trainer_SSN, Member_SSN, date, time, duration) 
VALUES 
('12345678901T', '12345678901', '2024-05-10', '08:00:00', 60),
('23456789012T', '23456789012', '2024-05-10', '09:00:00', 45),
('34567890123T', '34567890123', '2024-05-10', '10:00:00', 30),
('45678901234T', '45678901234', '2024-05-10', '11:00:00', 60),
('56789012345T', '56789012345', '2024-05-10', '12:00:00', 45),
('67890123456T', '67890123456', '2024-05-10', '13:00:00', 30),
('78901234567T', '78901234567', '2024-05-10', '14:00:00', 60),
('89012345678T', '89012345678', '2024-05-10', '15:00:00', 45),
('90123456789T', '90123456789', '2024-05-10', '16:00:00', 30),
('01234567890T', '01234567890', '2024-05-10', '17:00:00', 60);

SELECT * FROM MemberTrainerSession;

-- Inserting dummy data into the MemberFeedback table
INSERT INTO MemberFeedback (Trainer_SSN, Member_SSN, COMMENT, RATING, duration) 
VALUES 
('12345678901T', '12345678901', 'Great session!', 5.0, 60),
('23456789012T', '23456789012', 'I learned a lot!', 4.5, 45),
('34567890123T', '34567890123', 'Very motivating!', 4.8, 30),
('45678901234T', '45678901234', 'Awesome workout!', 5.0, 60),
('56789012345T', '56789012345', 'Best trainer ever!', 4.9, 45),
('67890123456T', '67890123456', 'Highly recommend!', 4.7, 30),
('78901234567T', '78901234567', 'Really helpful!', 4.8, 60),
('89012345678T', '89012345678', 'Excellent guidance!', 5.0, 45),
('90123456789T', '90123456789', 'Super knowledgeable!', 4.9, 30),
('01234567890T', '01234567890', 'Very professional!', 4.7, 60);

SELECT * FROM MemberFeedback;

-- Inserting dummy data into the TrainerAvailability table
INSERT INTO TrainerAvailability (date, time, Trainer_SSN) 
VALUES 
('2024-05-10', '08:00:00', '12345678901T'),
('2024-05-10', '09:00:00', '23456789012T'),
('2024-05-10', '10:00:00', '34567890123T'),
('2024-05-10', '11:00:00', '45678901234T'),
('2024-05-10', '12:00:00', '56789012345T'),
('2024-05-10', '13:00:00', '67890123456T'),
('2024-05-10', '14:00:00', '78901234567T'),
('2024-05-10', '15:00:00', '89012345678T'),
('2024-05-10', '16:00:00', '90123456789T'),
('2024-05-10', '17:00:00', '01234567890T');

SELECT * FROM TrainerAvailability;

-- Inserting dummy data into the TrainerSpecialty table
INSERT INTO TrainerSpecialty (specialty, Trainer_SSN) 
VALUES 
('Weight Training', '12345678901T'),
('Cardio', '23456789012T'),
('Yoga', '34567890123T'),
('Pilates', '45678901234T'),
('Crossfit', '56789012345T'),
('Zumba', '67890123456T'),
('Kickboxing', '78901234567T'),
('Cycling', '89012345678T'),
('HIIT', '90123456789T'),
('Functional Training', '01234567890T');

SELECT * FROM TrainerSpecialty;

-- Inserting dummy data into the TrainerQualification table
INSERT INTO TrainerQualification (qualification, Trainer_SSN) 
VALUES 
('Certified Personal Trainer', '12345678901T'),
('Certified Yoga Instructor', '23456789012T'),
('Certified Pilates Instructor', '34567890123T'),
('Certified Crossfit Coach', '45678901234T'),
('Certified Zumba Instructor', '56789012345T'),
('Certified Kickboxing Instructor', '67890123456T'),
('Certified Cycling Instructor', '78901234567T'),
('Certified HIIT Trainer', '89012345678T'),
('Certified Fitness Nutritionist', '90123456789T'),
('Certified Strength and Conditioning Specialist', '01234567890T');

SELECT * FROM TrainerQualification;

-- Inserting dummy data into the TrainerRegistrationSpecialty table
INSERT INTO TrainerRegistrationSpecialty (specialty, Trainer_SSN) 
VALUES 
('Weight Training', '12345678901T'),
('Cardio', '23456789012T'),
('Yoga', '34567890123T'),
('Pilates', '45678901234T'),
('Crossfit', '56789012345T'),
('Zumba', '67890123456T'),
('Kickboxing', '78901234567T'),
('Cycling', '89012345678T'),
('HIIT', '90123456789T'),
('Functional Training', '01234567890T');

SELECT * FROM TrainerRegistrationSpecialty;

-- Inserting dummy data into the TrainerRegistrationQualification table
INSERT INTO TrainerRegistrationQualification (qualification, Trainer_SSN) 
VALUES 
('Certified Personal Trainer', '12345678901T'),
('Certified Yoga Instructor', '23456789012T'),
('Certified Pilates Instructor', '34567890123T'),
('Certified Crossfit Coach', '45678901234T'),
('Certified Zumba Instructor', '56789012345T'),
('Certified Kickboxing Instructor', '67890123456T'),
('Certified Cycling Instructor', '78901234567T'),
('Certified HIIT Trainer', '89012345678T'),
('Certified Fitness Nutritionist', '90123456789T'),
('Certified Strength and Conditioning Specialist', '01234567890T');

SELECT * FROM TrainerRegistrationQualification;

-- Inserting dummy data into the GymApprovesTrainer table
INSERT INTO GymApprovesTrainer (GYM_SSN, Trainer_SSN) 
VALUES 
('12345678901GYM', '12345678901T'),
('23456789012GYM', '23456789012T'),
('34567890123GYM', '34567890123T'),
('45678901234GYM', '45678901234T'),
('56789012345GYM', '56789012345T'),
('67890123456GYM', '67890123456T'),
('78901234567GYM', '78901234567T'),
('89012345678GYM', '89012345678T'),
('90123456789GYM', '90123456789T'),
('01234567890GYM', '01234567890T');

SELECT * FROM GymApprovesTrainer;

-- Inserting dummy data into the Admin table
INSERT INTO Admin (SSN, Name, Gmail, Password) 
VALUES 
('12345678901A', 'Admin1', 'admin1@example.com', 'password31'),
('23456789012A', 'Admin2', 'admin2@example.com', 'password32'),
('34567890123A', 'Admin3', 'admin3@example.com', 'password33'),
('45678901234A', 'Admin4', 'admin4@example.com', 'password34'),
('56789012345A', 'Admin5', 'admin5@example.com', 'password35'),
('67890123456A', 'Admin6', 'admin6@example.com', 'password36'),
('78901234567A', 'Admin7', 'admin7@example.com', 'password37'),
('89012345678A', 'Admin8', 'admin8@example.com', 'password38'),
('90123456789A', 'Admin9', 'admin9@example.com', 'password39'),
('01234567890A', 'Admin10', 'admin10@example.com', 'password40');

SELECT * FROM Admin;

-- Inserting dummy data into the Diet table
INSERT INTO Diet (Diet_ID, Fats, Carbs, Proteins, Calories) 
VALUES 
(1, 50, 200, 100, 1500),
(2, 40, 180, 90, 1400),
(3, 45, 190, 95, 1450),
(4, 55, 220, 110, 1600),
(5, 60, 240, 120, 1700),
(6, 35, 170, 85, 1350),
(7, 65, 250, 125, 1800),
(8, 30, 160, 80, 1300),
(9, 70, 270, 135, 1900),
(10, 25, 150, 75, 1250);

SELECT * FROM Diet;

-- Inserting dummy data into the Equipment table
INSERT INTO Equipment (Equipment_ID, Category, Name) 
VALUES 
(1, 'Cardio', 'Treadmill'),
(2, 'Strength', 'Dumbbells'),
(3, 'Cardio', 'Stationary Bike'),
(4, 'Strength', 'Barbell'),
(5, 'Cardio', 'Elliptical Machine'),
(6, 'Strength', 'Kettlebells'),
(7, 'Cardio', 'Rowing Machine'),
(8, 'Strength', 'Bench Press'),
(9, 'Cardio', 'Stair Climber'),
(10, 'Strength', 'Leg Press');

SELECT * FROM Equipment;

-- Inserting dummy data into the GymUsesEquipment table
INSERT INTO GymUsesEquipment (Equipment_ID, GYM_SSN) 
VALUES 
(1, '12345678901GYM'),
(2, '23456789012GYM'),
(3, '34567890123GYM'),
(4, '45678901234GYM'),
(5, '56789012345GYM'),
(6, '67890123456GYM'),
(7, '78901234567GYM'),
(8, '89012345678GYM'),
(9, '90123456789GYM'),
(10, '01234567890GYM');

SELECT * FROM GymUsesEquipment;

-- Inserting dummy data into the Workout_Log table
INSERT INTO Workout_Log (Date, Time, Daily_Goal_Percentage, Member_SSN) 
VALUES 
('2024-05-10', '08:00:00', 90.0, '12345678901'),
('2024-05-10', '09:00:00', 85.0, '23456789012'),
('2024-05-10', '10:00:00', 95.0, '34567890123'),
('2024-05-10', '11:00:00', 80.0, '45678901234'),
('2024-05-10', '12:00:00', 92.0, '56789012345'),
('2024-05-10', '13:00:00', 88.0, '67890123456'),
('2024-05-10', '14:00:00', 94.0, '78901234567'),
('2024-05-10', '15:00:00', 82.0, '89012345678'),
('2024-05-10', '16:00:00', 96.0, '90123456789'),
('2024-05-10', '17:00:00', 85.0, '01234567890');

SELECT * FROM Workout_Log;

-- Inserting dummy data into the Diet_Log table
INSERT INTO Diet_Log (Weight, Meal_Name, Calories, Fats, Carbs, Proteins, date, time, Member_SSN) 
VALUES 
(70.2, 'Breakfast', 400, 20, 50, 25, '2024-05-10', '08:00:00', '12345678901'),
(55.8, 'Lunch', 350, 15, 40, 20, '2024-05-10', '12:00:00', '23456789012'),
(85.0, 'Dinner', 450, 25, 60, 30, '2024-05-10', '18:00:00', '34567890123'),
(60.5, 'Breakfast', 380, 18, 55, 22, '2024-05-10', '08:30:00', '45678901234'),
(75.6, 'Lunch', 320, 12, 45, 18, '2024-05-10', '12:30:00', '56789012345'),
(50.9, 'Dinner', 420, 22, 65, 28, '2024-05-10', '18:30:00', '67890123456'),
(80.3, 'Breakfast', 410, 24, 70, 32, '2024-05-10', '09:00:00', '78901234567'),
(58.7, 'Lunch', 340, 16, 48, 24, '2024-05-10', '13:00:00', '89012345678'),
(88.1, 'Dinner', 430, 26, 75, 35, '2024-05-10', '19:00:00', '90123456789'),
(53.4, 'Breakfast', 390, 19, 52, 26, '2024-05-10', '09:30:00', '01234567890');

SELECT * FROM Diet_Log;

-- Inserting dummy data into the Workout_Plan table
INSERT INTO Workout_Plan (Workout_ID, Name, Public_Flag, Category, Target_Muscle, Total_Time, Member_SSN, Trainer_SSN) 
VALUES 
(1, 'Cardio Blast', 1, 'Cardio', 'Full Body', 45, '12345678901', NULL),
(2, 'Strength Training', 1, 'Strength', 'Upper Body', 60, NULL, '12345678901T'),
(3, 'Yoga Flow', 1, 'Yoga', 'Flexibility', 30, '23456789012', NULL),
(4, 'Pilates Core Workout', 1, 'Pilates', 'Core', 45, '34567890123', NULL),
(5, 'Crossfit WOD', 1, 'Crossfit', 'Endurance', 60, NULL, '45678901234T'),
(6, 'Zumba Dance Party', 1, 'Cardio', 'Lower Body', 45, '56789012345', NULL),
(7, 'Kickboxing HIIT', 1, 'HIIT', 'Fat Burn', 30, '67890123456', NULL),
(8, 'Cycling Interval Ride', 1, 'Cardio', 'Legs', 60, '78901234567', NULL),
(9, 'Functional Training Circuit', 1, 'Functional Training', 'Strength', 45, NULL, '89012345678T'),
(10, 'Full Body Stretch', 1, 'Flexibility', 'Full Body', 30, '90123456789', NULL);

SELECT * FROM Workout_Plan;

-- Inserting dummy data into the WorkoutUsesEquipment table
INSERT INTO WorkoutUsesEquipment (Workout_ID, Equipment_ID, Sets, Reps) 
VALUES 
(1, 1, 3, 20),
(2, 2, 4, 15),
(3, 3, 2, 10),
(4, 4, 3, 15),
(5, 5, 4, 12),
(6, 6, 3, 20),
(7, 7, 2, 15),
(8, 8, 4, 10),
(9, 9, 3, 15),
(10, 10, 2, 10);

SELECT * FROM WorkoutUsesEquipment;

-- Inserting dummy data into the Diet_Plan table
INSERT INTO Diet_Plan (Diet_Plan_ID, Public_Flag, Time_Of_Day, New_Attribute, Member_SSN, Trainer_SSN) 
VALUES 
(1, 1, 'Morning', 'NewAttribute1', '12345678901', NULL),
(2, 1, 'Afternoon', 'NewAttribute2', '23456789012', NULL),
(3, 1, 'Evening', 'NewAttribute3', '34567890123', NULL),
(4, 1, 'Morning', 'NewAttribute4', '45678901234', NULL),
(5, 1, 'Afternoon', 'NewAttribute5', '56789012345', NULL),
(6, 1, 'Evening', 'NewAttribute6', '67890123456', NULL),
(7, 1, 'Morning', 'NewAttribute7', '78901234567', NULL),
(8, 1, 'Afternoon', 'NewAttribute8', '89012345678', NULL),
(9, 1, 'Evening', 'NewAttribute9', '90123456789', NULL),
(10, 1, 'Morning', 'NewAttribute10', '01234567890', NULL);

SELECT * FROM Diet_Plan;

-- Inserting dummy data into the DietPlanUsesDiet table
INSERT INTO DietPlanUsesDiet (Diet_Plan_ID, Diet_ID) 
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

SELECT * FROM DietPlanUsesDiet;

-- Inserting dummy data into the Membership table
INSERT INTO Membership (Membership_ID, GYM_SSN, Package, Join_Date, End_Date) 
VALUES 
(1, '12345678901GYM', 'Basic', '2024-01-01', '2024-12-31'),
(2, '23456789012GYM', 'Premium', '2024-02-01', '2024-12-31'),
(3, '34567890123GYM', 'Elite', '2024-03-01', '2024-12-31'),
(4, '45678901234GYM', 'Basic', '2024-04-01', '2024-12-31'),
(5, '56789012345GYM', 'Premium', '2024-05-01', '2024-12-31'),
(6, '67890123456GYM', 'Elite', '2024-06-01', '2024-12-31'),
(7, '78901234567GYM', 'Basic', '2024-07-01', '2024-12-31'),
(8, '89012345678GYM', 'Premium', '2024-08-01', '2024-12-31'),
(9, '90123456789GYM', 'Elite', '2024-09-01', '2024-12-31'),
(10, '01234567890GYM', 'Basic', '2024-10-01', '2024-12-31');

SELECT * FROM Membership;

-- Inserting dummy data into the WeeklyPlan table
INSERT INTO WeeklyPlan (Member_SSN, day, Workout_ID, Diet_Plan_ID) 
VALUES 
('12345678901', 'Monday', 1, 1),
('23456789012', 'Tuesday', 2, 2),
('34567890123', 'Wednesday', 3, 3),
('45678901234', 'Thursday', 4, 4),
('56789012345', 'Friday', 5, 5),
('67890123456', 'Saturday', 6, 6),
('78901234567', 'Sunday', 7, 7),
('89012345678', 'Monday', 8, 8),
('90123456789', 'Tuesday', 9, 9),
('01234567890', 'Wednesday', 10, 10);

SELECT * FROM WeeklyPlan;
