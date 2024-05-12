CREATE DATABASE FlexTrainer2;
DROP DATABASE FlexTrainer2;
USE FlexTrainer2;

CREATE TABLE Member (
    Member_SSN VARCHAR(11) PRIMARY KEY,
	  Gender VARCHAR(10),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    Height FLOAT,
    Weight FLOAT,
  );

  
CREATE TABLE Trainer (
    Trainer_SSN VARCHAR(11) PRIMARY KEY,
    Gender VARCHAR(10),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
	YoE FLOAT
   );

CREATE TABLE Gym_Owner (
    GO_SSN VARCHAR(11) PRIMARY KEY,
    Gender VARCHAR(10),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50)
	);

CREATE TABLE Gym (
    GYM_SSN VARCHAR(11) PRIMARY KEY,
    Name VARCHAR(50),
    Location VARCHAR(100),
    Gmail VARCHAR(100),
	GO_SSN VARCHAR(11),
	FOREIGN KEY (GO_SSN) REFERENCES Gym_Owner(GO_SSN)
	);
CREATE TABLE Member_Registration (
    Member_SSN VARCHAR(11) PRIMARY KEY,
	Gender VARCHAR(10),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
    Height FLOAT,
    Weight FLOAT,
    GYM_SSN VARCHAR(11),
    FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN)
  );
  
CREATE TABLE Trainer_Registration (
    Trainer_SSN VARCHAR(11) PRIMARY KEY,
    Gender VARCHAR(10),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50),
	YoE FLOAT,
    GYM_SSN VARCHAR(11),
    FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN)
   );

------------------------------------- deprected ----------------------------------------------
CREATE TABLE TrainerRegistrationSpecialty
(
   specialty varchar(500),
    Trainer_SSN VARCHAR(11),
	FOREIGN KEY (Trainer_SSN) REFERENCES Trainer_Registration(Trainer_SSN)

);

CREATE TABLE TrainerRegistrationQualification
(
   qualification varchar(500),
    Trainer_SSN VARCHAR(11),
	FOREIGN KEY (Trainer_SSN) REFERENCES Trainer_Registration(Trainer_SSN)

);
-----------------------------------------------------------------------------------------------

CREATE TABLE MemberjoinGym
(
 GYM_SSN VARCHAR(11),
  Member_SSN VARCHAR(11),
 FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN),
 FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN)
);


CREATE TABLE Gym_Owner_Registration (
    GO_SSN VARCHAR(11) PRIMARY KEY,
    Gender VARCHAR(10),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
    First_Name VARCHAR(50),
    Last_Name VARCHAR(50)
	);

CREATE TABLE Gym_Registration (
    GYM_SSN VARCHAR(11) PRIMARY KEY,
    Name VARCHAR(50),
    Location VARCHAR(100),
    Gmail VARCHAR(100),
	GO_SSN VARCHAR(11),
	FOREIGN KEY (GO_SSN) REFERENCES Gym_Owner(GO_SSN)
	);


CREATE TABLE TrainerWorksGym
(
 GYM_SSN VARCHAR(11),
  Trainer_SSN VARCHAR(11),
 FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN),
  FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN)
	
);
CREATE TABLE MemberTrainerSession
(
 Trainer_SSN VARCHAR(11),
 Member_SSN VARCHAR(11),
 date DATE,
 time TIME,
 duration NUMERIC,
 FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN),
FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN)

);

CREATE TABLE MemberFeedback
(
 Trainer_SSN VARCHAR(11),
 Member_SSN VARCHAR(11),
 COMMENT VARCHAR(500),
 RATING FLOAT,
 duration NUMERIC,
 FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN),
FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN)

CREATE TABLE TrainerAvailability
(
    date DATE,
    start_time TIME,
    end_time TIME,
    Trainer_SSN VARCHAR(11),
    FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN)
);

CREATE TABLE TrainerSpecialty
(
   specialty varchar(500),
    Trainer_SSN VARCHAR(11),
	FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN)

);

CREATE TABLE TrainerQualification
(
   qualification varchar(500),
    Trainer_SSN VARCHAR(11),
	FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN)

);


CREATE TABLE Admin (
    SSN VARCHAR(11) PRIMARY KEY,
    Name VARCHAR(50),
    Gmail VARCHAR(100),
    Password VARCHAR(50),
   );



CREATE TABLE Equipment (
    Equipment_ID INT PRIMARY KEY,
    Category VARCHAR(50),
    Name VARCHAR(50)
);

CREATE TABLE GymUsesEquipment
(

   Equipment_ID INT,
   GYM_SSN VARCHAR(11),
 
  FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN),
  FOREIGN KEY (Equipment_ID) REFERENCES Equipment(Equipment_ID)

);

CREATE TABLE Workout_Log (
   
    Date DATE,
    Time TIME,
    Daily_Goal_Percentage float,
	 Member_SSN VARCHAR(11),
	  FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN)

);

CREATE TABLE Diet_Log (
   
    Weight FLOAT,
    Meal_Name VARCHAR(50),
    Calories INT,
    Fats INT,
    Carbs INT,
    Proteins INT,
	date DATE,
	time TIME,
	 Member_SSN VARCHAR(11),
	  FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN)

);
---------------------------------------------------------------------------------------------------------
CREATE TABLE Workout_Plan (
    Workout_ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Public_Flag BIT,
    Category VARCHAR(50),
    Target_Muscle VARCHAR(50),
    Total_Time INT,
    Member_SSN VARCHAR(11),
    Trainer_SSN VARCHAR(11),
    CONSTRAINT CHK_Workout_Plan_SSN CHECK (
        (Member_SSN IS NOT NULL AND Trainer_SSN IS NULL) OR
        (Member_SSN IS NULL AND Trainer_SSN IS NOT NULL)
    ),
    FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN),
    FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN)
);


CREATE TABLE WorkoutUsesEquipment (
    Workout_ID INT,
    Equipment_ID INT,
    Sets INT,
    Reps INT,
    FOREIGN KEY (Workout_ID) REFERENCES Workout_Plan(Workout_ID),
    FOREIGN KEY (Equipment_ID) REFERENCES Equipment(Equipment_ID)
);

---------------------------------------------------------------------------------------------------------
CREATE TABLE Diet_Plan (
    Diet_Plan_ID INT PRIMARY KEY,
    Public_Flag BIT,
    DietPlan_Name VARCHAR(50),
    Type_Diet_Plan VARCHAR(50),
    Time_Of_Day VARCHAR(50),
    Member_SSN VARCHAR(11),
    Trainer_SSN VARCHAR(11),
    CONSTRAINT CHK_Diet_Plan_SSN CHECK (
        (Member_SSN IS NOT NULL AND Trainer_SSN IS NULL) OR
        (Member_SSN IS NULL AND Trainer_SSN IS NOT NULL)
    ),
    FOREIGN KEY (Trainer_SSN) REFERENCES Trainer(Trainer_SSN),
    FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN)
);

CREATE TABLE Diet (
    Diet_ID INT PRIMARY KEY,
    deit_name VARCHAR(50),
    Fats INT,
    Carbs INT,
    Proteins INT,
    Calories INT
);


CREATE TABLE DietPlanUsesDiet (
    Diet_Plan_ID INT,
    Diet_ID INT,
    Quantity INT,
    FOREIGN KEY (Diet_ID) REFERENCES Diet(Diet_ID),
    FOREIGN KEY (Diet_Plan_ID) REFERENCES Diet_Plan(Diet_Plan_ID)
);


---------------------------------------------------------------------------------------------------------
-- this is gym membership viewed by admin
CREATE TABLE Membership (
    Membership_ID INT PRIMARY KEY,
    GYM_SSN VARCHAR(11),
    Package VARCHAR(50),
    Join_Date DATE,
    End_Date DATE,
    FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN)
);

CREATE TABLE MemberHasGymMembership (
    Member_SSN VARCHAR(11),
    GYM_SSN VARCHAR(11),
    Start_Date DATE,
    End_Date DATE,
    type_membership VARCHAR(50),
    FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN),
    FOREIGN KEY (GYM_SSN) REFERENCES Gym(GYM_SSN)
);

CREATE TABLE WeeklyPlan
(
   Member_SSN VARCHAR(11),
   day VARCHAR(10),
    Workout_ID INT,
	 Diet_Plan_ID INT,
	 FOREIGN KEY (Diet_Plan_ID) REFERENCES Diet_Plan(Diet_Plan_ID),
   FOREIGN KEY (Workout_ID) REFERENCES Workout_Plan(Workout_ID),
   FOREIGN KEY (Member_SSN) REFERENCES Member(Member_SSN),
);

-- WeeklyPlan( Member_SSN, day, Workout_ID, Diet_Plan_ID)

CREATE TABLE ChangeLog (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    TableName VARCHAR(100),
    ActionPerformed VARCHAR(10), -- INSERT, DELETE, etc.
    ChangeDate DATETIME DEFAULT GETDATE(),
    ChangedData NVARCHAR(MAX) -- JSON or XML representation of the changed data
);