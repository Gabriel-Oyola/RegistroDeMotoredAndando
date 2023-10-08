using System;
using System.Collections.Generic;

namespace ProyectoPracticaII.Client.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public virtual ICollection<Motocicleta> Motocicleta { get; set; } = new List<Motocicleta>();

    public virtual ICollection<Opinione> Opiniones { get; set; } = new List<Opinione>();

    public virtual ICollection<Taller> Tallers { get; set; } = new List<Taller>();
}
