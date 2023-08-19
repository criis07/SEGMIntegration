using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lafise.SEGMIntegration.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Entities;

namespace Lafise.SEGMIntegration.Application.features.SEGM.Dto
{
    [DataContract]
    public class RegistrationDto : RegistrationRequestBody
    {
        public bool succeeded { get; set; }

        public string? message { get; set; }

        public string? errors { get; set; }

        public string? data { get; set; }

    }
}
