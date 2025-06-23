﻿using System;
using System.Collections.Generic;

namespace PruebaTecnicaMyper.Domain.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string? NombreDepartamento { get; set; }

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();

    public virtual ICollection<Trabajador> Trabajadores { get; set; } = new List<Trabajador>();
}
