# Database Documentation

## Introduction

This document provides an overview of the **FlexTrainer2** database. It describes the database schema, functions, stored procedures, and their usage.

## Database Schema

The database consists of the following tables:

- **Member**: Contains information about gym members.
- **Trainer**: Stores details of trainers.
- **Gym_Owner**: Holds data related to gym owners.
- **Gym**: Stores gym information.
- **Member_Registration**: Records member registration requests.
- **MemberjoinGym**: Represents the relationship between members and gyms.
- **Trainer_Registration**: Stores trainer registration requests.
- **Gym_Owner_Registration**: Records gym owner registration requests.
- **Gym_Registration**: Tracks gym registration requests.
- **TrainerWorksGym**: Represents the relationship between trainers and gyms.
- **MemberTrainerSession**: Records sessions between members and trainers.
- **MemberFeedback**: Stores feedback provided by members.
- **TrainerAvailability**: Tracks the availability of trainers.
- **TrainerSpecialty**: Contains specialties of trainers.
- **TrainerQualification**: Stores qualifications of trainers.
- **TrainerRegistrationSpecialty**: Maps specialties to trainers during registration.
- **TrainerRegistrationQualification**: Maps qualifications to trainers during registration.
- **GymApprovesTrainer**: Records approval of trainers by gyms.
- **Admin**: Stores information about system administrators.
- **Equipment**: Contains details of gym equipment.
- **GymUsesEquipment**: Represents the relationship between gyms and equipment.
- **Workout_Log**: Logs workout sessions.
- **Diet_Log**: Logs diet information.
- **Workout_Plan**: Stores workout plans.
- **WorkoutUsesEquipment**: Represents the relationship between workouts and equipment.
- **Diet_Plan**: Contains diet plans.
- **Diet**: Stores details of diets.
- **DietPlanUsesDiet**: Represents the relationship between diet plans and diets.
- **Membership**: Tracks gym memberships.
- **MemberHasGymMembership**: Represents the relationship between members and gym memberships.
- **WeeklyPlan**: Stores weekly plans.

## Functions and Procedures

The database includes several functions and procedures to facilitate various operations:

- **GetWorkoutEquipmentDetails**: Retrieves details of workout plans.
- **GetPrivateWorkoutEquipmentDetails**: Retrieves private workout plan details.
- **GetMuscleTypes**: Returns all muscle types.
- **GetWorkoutEquipmentDetailsByMuscle**: Retrieves workout plans by muscle type.
- **GetWorkoutCategory**: Returns all workout categories.
- **GetWorkoutEquipmentDetailsByCategory**: Retrieves workout plans by category.
- **GetWorkoutEquipmentDetailsByName**: Retrieves workout plans by name.
- **GetWorkoutEquipmentDetailsByFilters**: Retrieves workout plans based on specified filters.
- **CreateWorkoutPlan**: Creates a new workout plan.
- **AddEquipmentToWorkoutPlan**: Adds equipment to a workout plan.
- **GetDietPlanDetails**: Retrieves details of diet plans.
- **GetDietType**: Returns all diet types.
- **GetDayTime**: Returns all day times.
- **GetDietPlanDetailsByFats**: Retrieves diet plans with fats below a threshold.
- **GetDietPlanDetailsByCals**: Retrieves diet plans with calories below a threshold.
- **GetDietPlanDetailsByName**: Retrieves diet plans by name.
- **CreateDietPlan**: Creates a new diet plan.
- **AddDietToDietPlan**: Adds a diet to a diet plan.
- **GetGymsByOwner**: Retrieves gyms owned by a gym owner.
- **GetTrainersByGym**: Retrieves trainers associated with a gym.
- **GetTrainersByGymAndName**: Retrieves trainers by gym and name.
- **GetTrainersByGymAndYoE**: Retrieves trainers by gym and years of experience.
- **RemoveTrainerFromGym**: Removes a trainer from a gym.
- **GetMembersByGym**: Retrieves members associated with a gym.
- **GetMembershipTypes**: Returns all membership types.
- **GetMembersByGymAndName**: Retrieves members by gym and name.
- **RemoveMemberFromGym**: Removes a member from a gym.
- **GetMemberRegistrationRequests**: Retrieves member registration requests.
- **CreateMemberRegistrationRequest**: Creates a new member registration request.
- **CreateTrainerRegistrationRequest**: Creates a new trainer registration request.
- **CreateGymOwnerRegistrationRequest**: Creates a new gym owner registration request.
- **GetMemberRegistrationRequestsByGym**: Retrieves member registration requests by gym.
- **GetTrainerRegistrationRequestsByGym**: Retrieves trainer registration requests by gym.
- **ApproveMemberRegistrationRequest**: Approves a member registration request.
- **ApproveTrainerRegistrationRequest**: Approves a trainer registration request.
- **RejectMemberRegistrationRequest**: Rejects a member registration request.
- **RejectTrainerRegistrationRequest**: Rejects a trainer registration request.
