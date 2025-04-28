using Application.Trainings.Commands.AddParticipantToTraining;
using Application.Trainings.Commands.CreateTraining;
using Application.Trainings.Commands.UpdateTraining;
using Application.Trainings.Queries.GetTraining;
using Application.Trainings.Queries.GetUpcomingTrainings;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts;

namespace Presentation.Controllers;


[Route("/api/trainings")]
public class TrainingController : BaseApiController
{

	public TrainingController(ISender sender) : base(sender) { }


	[HttpGet]
	public async Task<IActionResult> GetTrainings()
	{
		var response = await Sender.Send(new GetUpcomingTrainingsQuery());

		if (response.IsFailure)
			return HandleFailure(response);

		return Ok(response.Value);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTraining(int id)
	{
		var response = await Sender.Send(new GetTrainingQuery(id));

		if (response.IsFailure)
			return HandleFailure(response);

		return Ok(response.Value);
	}

	[HttpPost]
	public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingRequest request)
	{

		var response = await Sender.Send(new CreateTrainingCommand(request.ScheduledAt, request.TrainingTypeId, request.MaxParticipants));

		if (response.IsFailure)
			return HandleFailure(response);

		return Ok();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateTraining(int id, [FromBody] UpdateTrainingRequest  request)
	{
		var response = await Sender.Send(new UpdateTrainingCommand(id, request.ScheduledAt, request.MaxParticipants));

		if (response.IsFailure)
			return HandleFailure(response);

		return Ok();
	}


	[HttpPost("{trainingId}/participants")]
	public async Task<IActionResult> AddParticipantToTraining(int trainingId)
	{
		var response = await Sender.Send(new AddParticipantToTrainingCommand(trainingId));

		if (response.IsFailure)
			return HandleFailure(response);

		return Ok();
	}
}