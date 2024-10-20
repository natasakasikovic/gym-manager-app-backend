using GymManagerApp.Domain.Entities.User;

namespace GymManagerApp.Domain.Entities.Training
{
    public class Training
    {
        public int Id { get; set; }
        public TrainingType Type { get; set; }
        public Trainer Trainer { get; set; }

        public Training() { }

    }
}
