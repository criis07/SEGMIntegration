using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lafise.SEGMIntegration.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Entities;

namespace Lafise.SEGMIntegration.Application.Common.Interfaces
{
    public interface ISEGMService
    {
        Task<Result<SecurityInterestsTypes>> GetTypesSecurityInterest();
        Task<Result<NoticesTypes>> GetRegistrationNoticeTypes();
    }
}
