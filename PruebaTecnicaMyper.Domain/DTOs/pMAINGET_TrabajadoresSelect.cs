using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMyper.Domain.DTOs
{
    public class pMAINGET_TrabajadoresSelect
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Sexo { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Departamento { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
    }
}
