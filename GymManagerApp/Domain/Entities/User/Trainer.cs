using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Domain.Entities.User;

public class Trainer : User {
    List<TrainingType> specializations;
}
