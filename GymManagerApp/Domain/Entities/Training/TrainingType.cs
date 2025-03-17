using GymManagerApp.Domain.Entities.Common;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities.Training
{
	public class TrainingType : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TrainingIntensity Intensity { get; private set; }

        private TrainingType() { }

        private TrainingType(int id, string name, string description, TrainingIntensity intensity)
        {
            Id = id;
            Name = name;
            Description = description;
            Intensity = intensity;
        }

        public static TrainingType Create (int id, string name, string description, TrainingIntensity intensity)
        {
            return new TrainingType(id, name, description, intensity);
        }

        public void Update (string name, string description, TrainingIntensity intensity)
        {
            Name = name;
            Description = description;
            Intensity = intensity;
        }
    }
}
