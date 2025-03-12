using GymManagerApp.Domain.Entities.Common;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities.Training
{
    public class TrainingType : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TrainingIntensity Intensity { get; private set; }

        private TrainingType() { }

    }
}
