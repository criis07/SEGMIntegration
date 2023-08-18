using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lafise.test.Domain.Entities.SEGM
{
    public class NoticesTypes
    {
        public bool succeeded { get; set; }
        public string? message { get; set; }
        public string? errors { get; set; }
        public Notices[]? data { get; set; }
    }

    public class Notices
    {
        public int id { get; set; }
        public string? tipoAvisoInscripcion { get; set; }
        public string? tipoAvisoPresentacion { get; set; }
        public float costo { get; set; }
        public string? descripcion { get; set; }
        public bool controlAviso { get; set; }
        public bool estatus { get; set; }
    }

}
