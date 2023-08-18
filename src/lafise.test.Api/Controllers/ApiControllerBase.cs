using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace lafise.test.Api.Controllers
{
    /// <summary>
    /// Base controller with application layer mediator
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        /// <summary>
        /// Mediator sender
        /// </summary>
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
