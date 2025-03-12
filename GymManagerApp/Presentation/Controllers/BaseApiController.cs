using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerApp.Presentation.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {

        protected readonly ISender Sender;

        protected BaseApiController(ISender sender) {
            Sender = sender;
        }
    }
}