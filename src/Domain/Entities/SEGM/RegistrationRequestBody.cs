using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Lafise.SEGMIntegration.Domain.Entities.SEGM.RegistrationRequestBody;

namespace Lafise.SEGMIntegration.Domain.Entities.SEGM
{
    public class RegistrationRequestBody
    {
        public Operaciones? operaciones { get; set; }
        public Acreedores? acreedores { get; set; }
        public Deudores? deudores { get; set; }
        public Bienes? bienes { get; set; }
        public class Operaciones
        {
            public int idTipoAvisoInscripcion { get; set; }
            public int tipoConciliacion { get; set; }
            public DateTime fechaVencimiento { get; set; }
            public string? comentarios { get; set; }
            public string? moneda { get; set; }
            public int monto { get; set; }
            public int tipoDeGarantiaMobiliario { get; set; }
        }

        public class Acreedores
        {
            public string? rncCedula { get; set; }
            public string? nombreAcreedor { get; set; }
            public string? idMunicipio { get; set; }
            public string? domicilio { get; set; }
            public string? correoElectronico { get; set; }
            public string? telefono { get; set; }
            public bool nacional { get; set; }
        }

        public class Deudores
        {
            public int idTipoDeudor { get; set; }
            public string? rncCedula { get; set; }
            public string? nombreDeudor { get; set; }
            public string? idMunicipio { get; set; }
            public string? domicilio { get; set; }
            public string? correoElectronico { get; set; }
            public string? telefono { get; set; }
            public bool nacional { get; set; }
        }

        public class Bienes
        {
            public int idTipoPropiedad { get; set; }
            public int idTipoBien { get; set; }
            public string? numeroSerial { get; set; }
            public string? descripcionBien { get; set; }
            public bool incorporacionInmueble { get; set; }
            public string? incorporacionInmuebleDescripcion { get; set; }
            public string? registroDondeSeEnCuentraInscrito { get; set; }
            public string? ubicacionDelInmueble { get; set; }
        }
    }
}
