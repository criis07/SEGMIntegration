using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Lafise.SEGMIntegration.Application.Common.Interfaces;
using Lafise.SEGMIntegration.Application.features.SEGM.Dto;
using Lafise.SEGMIntegration.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Enums;
using LAFISE.CrossCutting.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Lafise.SEGMIntegration.Application.features.SEGM.Commands
{
    public class CreateRegistrationCommand : RegistrationRequestBody, IRequest<RegistrationDto>, IMapFrom<RegistrationDto>, IMapFrom<RegistrationRequestBody>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegistrationRequestBody, CreateRegistrationCommand>().ReverseMap();
            profile.CreateMap<CreateRegistrationCommand, RegistrationRequestBody>();
        }

    }
    public class CreateRegistrationValidator : AbstractValidator<CreateRegistrationCommand>
    {

    }

    public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, RegistrationDto>
    {
        private readonly IMapper _mapper;

        private readonly ILogger<CreateRegistrationCommandHandler> _logger;

        private readonly ISEGMService _SEGMService;

        public CreateRegistrationCommandHandler(IMapper mapper, ILogger<CreateRegistrationCommandHandler> logger, ISEGMService SEGMService)
        {
            _mapper = mapper;
            _logger = logger;
            _SEGMService = SEGMService;
        }

        public async Task<RegistrationDto> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
        {
            var notice = await _SEGMService.GetRegistrationNoticeTypes();
            var security = await _SEGMService.GetTypesSecurityInterest();
            var list = new List<Data>();
            list = security.Data.data?.ToList();
            return null;
        }
    }
}
