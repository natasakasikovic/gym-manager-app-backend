using GymManagerApp.Application.TrainingType.Queries.GetTrainingTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerApp.Presentation.Controllers
{
	[Route("/api/training-types")]

	public class TrainingTypeController : BaseApiController
	{
		public TrainingTypeController(ISender sender) : base(sender) { }

		[HttpGet]
		public async Task<IActionResult> GetTrainingTypes()
		{
			var response = await Sender.Send(new GetTrainingTypesQuery());

			if (response.IsFailure)
				return Ok(response); // TODO: replace with HandleError method

			return Ok(response);
		}

	}
}
