using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface ITrainingTypeRepository : IRepository<TrainingType> {
	Task<bool> IsTrainingTypeNameUniqueAsync(string name, CancellationToken cancellationToken);
	Task<bool> IsTrainingTypeNameUniqueAsync(int id, string name, CancellationToken cancellationToken);
}