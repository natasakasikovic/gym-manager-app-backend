using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities.Training
{
    public class TrainingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingIntensity Intensity { get; set; }

        public TrainingType() { }

    }
}
