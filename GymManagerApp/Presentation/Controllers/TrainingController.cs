using GymManagerApp.Application.CQRS.Queries.GetTrainings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerApp.Presentation.Controllers
{
	[Route("/api/trainings")]
    public class TrainingController : BaseApiController
    {

        public TrainingController(ISender sender) : base(sender) { }


        [HttpGet]
        public async Task<IActionResult> GetTrainings()
        {
            var response = await Sender.Send(new GetTrainingsQuery());   

            if (response.IsFailure)
                return Ok(response); // TODO: make HandleFailure method!

            return Ok(response);
        }

    }
}
