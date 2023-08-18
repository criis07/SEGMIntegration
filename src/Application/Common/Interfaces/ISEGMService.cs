using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lafise.test.Domain.Entities.SEGM;
using LAFISE.CrossCutting.Core.Entities;

namespace lafise.test.Application.Common.Interfaces
{
    public interface ISEGMService
    {
        Task<Result<SecurityInterestsTypes>> GetTypesSecurityInterest();
        Task<Result<NoticesTypes>> GetRegistrationNoticeTypes();
    }
}
