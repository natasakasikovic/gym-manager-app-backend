using GymManagerApp.Domain.Common;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities
{
    public class TrainingType : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TrainingIntensity Intensity { get; private set; }

        private TrainingType() { }

        private TrainingType(string name, string description, TrainingIntensity intensity)
        {
            Name = name;
            Description = description;
            Intensity = intensity;
        }

        public static TrainingType Create(string name, string description, TrainingIntensity intensity)
        {
            return new TrainingType(name, description, intensity);
        }

        public void Update(string name, string description, TrainingIntensity intensity)
        {
            Name = name;
            Description = description;
            Intensity = intensity;
        }
    }
}
