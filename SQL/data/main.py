# List of file names
file_names = [
    "Member.csv",
    "Trainer.csv",
    "Gym_Owner.csv",
    "Gym.csv",
    "Member_Registration.csv",
    "Trainer_Registration.csv",
    "TrainerRegistrationSpecialty.csv",
    "TrainerRegistrationQualification.csv",
    "MemberjoinGym.csv",
    "Gym_Owner_Registration.csv",
    "Gym_Registration.csv",
    "TrainerWorksGym.csv",
    "MemberTrainerSession.csv",
    "MemberFeedback.csv",
    "TrainerAvailability.csv",
    "TrainerSpecialty.csv",
    "TrainerQualification.csv",
    "Equipment.csv",
    "GymUsesEquipment.csv",
    "Workout_Log.csv",
    "Diet_Log.csv",
    "Workout_Plan.csv",
    "WorkoutUsesEquipment.csv",
    "Diet_Plan.csv",
    "DietPlanUsesDiet.csv",
    "Membership.csv",
    "MemberHasGymMembership.csv",
    "WeeklyPlan.csv",
    "ChangeLog.csv",
    "allergens.csv",
    "GymLog.csv"
]

# Create blank files
for file_name in file_names:
    with open(file_name, "w") as f:
        pass  # This creates an empty file

print("All files created successfully.")
