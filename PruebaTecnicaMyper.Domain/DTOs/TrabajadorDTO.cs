using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaMyper.Domain.DTOs;

public class TrabajadorDTO
{
    public int Id { get; set; }
    public string? TipoDocumento { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Nombres { get; set; }
    public string? Sexo { get; set; }
    public int? IdDepartamento { get; set; }
    public int? IdProvincia { get; set; }
    public int? IdDistrito { get; set; }
}
