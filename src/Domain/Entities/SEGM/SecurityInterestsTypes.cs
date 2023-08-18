using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lafise.test.Domain.Entities.SEGM
{
    public class SecurityInterestsTypes
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public bool succeeded { get; set; }
        public string? message { get; set; }
        public string? errors { get; set; }
        public Data[]? data { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string? nombreGarantia { get; set; }
    }
}
