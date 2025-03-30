using Azure.Core;
using GymManagerApp.Application.CQRS.Queries.GetTrainings;
using GymManagerApp.Application.Trainings.Commands.AddParticipantToTraining;
using GymManagerApp.Application.Trainings.Commands.CreateTraining;
using GymManagerApp.Application.Trainings.Commands.UpdateTraining;
using GymManagerApp.Application.Trainings.Queries.GetTraining;
using GymManagerApp.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerApp.Presentation.Controllers;

[Route("/api/trainings")]
public class TrainingController : BaseApiController
{

    public TrainingController(ISender sender) : base(sender) { }


    [HttpGet]
    public async Task<IActionResult> GetTrainings()
    {
        var response = await Sender.Send(new GetUpcomingTrainingsQuery());   

        if (response.IsFailure)
            return HandleFaluire(response);

        return Ok(response.Value);
    }

	[HttpGet("{id}")]
	public async Task<IActionResult> GetTraining(int id)
	{
		var response = await Sender.Send(new GetTrainingQuery(id));

		if (response.IsFailure)
			return HandleFaluire(response);

		return Ok(response.Value);
	}

	[HttpPost]
    public async Task<IActionResult> CreateTraining([FromBody] CreateTrainingRequest request)
    {
        var response = await Sender.Send(new CreateTrainingCommand(request.ScheduledAt, request.TrainingTypeId, request.TrainerId, request.MaxParticipants));
            
        if (response.IsFailure) 
            return HandleFaluire(response); 

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTraining(int id, [FromBody] UpdateTrainingRequest request)
    {
		var response = await Sender.Send(new UpdateTrainingCommand(id, request.ScheduledAt, request.MaxParticipants));

		if (response.IsFailure)
			return HandleFaluire(response);

		return Ok();
	}


	[HttpPost("{trainingId}/participants/participantId")]
	public async Task<IActionResult> AddParticipantToTraining(int trainingId, int participantId) // TODO: remove participantId and take it from token!
	{
		var response = await Sender.Send(new AddParticipantToTrainingCommand(trainingId, participantId));

		if (response.IsFailure)
			return HandleFaluire(response);

		return Ok();
	}
}