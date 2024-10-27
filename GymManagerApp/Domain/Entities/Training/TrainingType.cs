using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities.Training
{
    public class TrainingType : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingIntensity Intensity { get; set; }

        public TrainingType() { }

    }
}
