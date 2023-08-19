using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Lafise.SEGMIntegration.Api.Controllers;
using Lafise.SEGMIntegration.Api.Filters;
using Lafise.SEGMIntegration.Application.features.SEGM.Commands;
using Lafise.SEGMIntegration.Application.features.SEGM.Dto;
using Lafise.SEGMIntegration.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lafise.SEGMIntegration.Api.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class SEGMController : ApiControllerBase
    {

        private readonly IMapper _mapper;

        /// <summary>
        /// Si
        /// </summary>
        /// <param name="mapper">Tambien</param>
        public SEGMController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // POST: SEGMController/Auth

        /// <summary>
        /// Create registration
        /// </summary>
        /// <param name="BODY">The required body</param>   
        [HttpPost]
        [ValidateModelState]
        [Route("//api/v1/SEGM/registration")]
        [ProducesResponseType(type: typeof(RegistrationDto), statusCode: 201)]
        public virtual async Task<IActionResult> APIv1CreateRegistration([FromBody][Required] RegistrationRequestBody BODY)
        {

            var response = await Mediator.Send(_mapper.Map<CreateRegistrationCommand>(BODY));

            return Created(string.Empty, response);
        }

    }
}
