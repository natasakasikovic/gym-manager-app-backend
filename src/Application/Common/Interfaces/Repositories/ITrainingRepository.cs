using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface ITrainingRepository : IRepository<Training> {
	Task<bool> ExistsByTrainingTypeIdAsync(int trainingTypeId);
}