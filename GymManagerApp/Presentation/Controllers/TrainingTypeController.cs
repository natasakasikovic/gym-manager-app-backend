using GymManagerApp.Application.TrainingTypes.Commands.CreateTrainingType;
using GymManagerApp.Application.TrainingTypes.Commands.UpdateTrainingType;
using GymManagerApp.Application.TrainingTypes.Queries.GetTrainingTypes;
using GymManagerApp.Presentation.Contracts;
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

			return Ok(response.Value);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTrainingType(int id, [FromBody] UpdateTrainingTypeRequest request)
		{
			var response = await Sender.Send(new UpdateTrainingTypeCommand(id, request.Name, request.Description, request.Intensity));

			if (response.IsFailure)
				return Ok(); // TODO: replace with HandleError method

			return Ok(response.Value);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTrainingType([FromBody] CreateTrainingTypeRequest request)
		{
			var response = await Sender.Send(new CreateTrainingTypeCommand(request.Name, request.Description, request.Intensity));

			if (response.IsFailure)
				return Ok(); // TODO: replace with HandleError method

			return Ok();
		}
	}
}
