using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lafise.SEGMIntegration.Domain.Entities.SEGM
{

    public class AuthResponse
    {
        public bool succeeded { get; set; }
        public string? message { get; set; }
        public string? errors { get; set; }
        public DataAuth? data { get; set; }
    }

    public class DataAuth
    {
        public string? jwToken { get; set; }
        public DateTime expiration { get; set; }
    }

}
