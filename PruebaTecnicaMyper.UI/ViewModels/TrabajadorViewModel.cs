using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaMyper.UI.ViewModels;

public class TrabajadorViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo Tipo Doc. es obligatorio")]
    public string? TipoDocumento { get; set; }
    [Required(ErrorMessage = "El campo número de Documento es obligatorio")]
    public string? NumeroDocumento { get; set; }
    [StringLength(50, ErrorMessage = "El campo nombres no debe superar los 50 caracteres")]
    [Required(ErrorMessage = "El campo nombres es obligatorio")]
    public string? Nombres { get; set; }
    public string? Sexo { get; set; }
    [Required(ErrorMessage = "El campo departamento es obligatorio")]
    public int? IdDepartamento { get; set; }
    [Required(ErrorMessage = "El campo provincia es obligatorio")]
    public int? IdProvincia { get; set; }
    [Required(ErrorMessage = "El campo distrito es obligatorio")]
    public int? IdDistrito { get; set; }

}
