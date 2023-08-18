using System.ComponentModel.DataAnnotations;
using AutoMapper;
using lafise.test.Api.Filters;
using lafise.test.Application.features.SEGM;
using lafise.test.Application.features.SEGM.Commands;
using lafise.test.Application.features.SEGM.Dto;
using lafise.test.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lafise.test.Api.Controllers.v1
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
