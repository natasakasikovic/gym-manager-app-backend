using GymManagerApp.Domain.Entities.User;

namespace GymManagerApp.Domain.Entities.Training
{
    public class Training : Entity
    {
        public TrainingType Type { get; set; }
        public Trainer Trainer { get; set; }

        public Training() { }

    }
}
