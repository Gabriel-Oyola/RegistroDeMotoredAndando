using System;
using System.Collections.Generic;

namespace ProyectoPracticaII.Client.Models;

public partial class TallerTop
{
    public int? IdTaller { get; set; }

    public int? Rating { get; set; }

    public string? Nombre { get; set; }

    public string? LinkTaller { get; set; }

    public virtual Taller? IdTallerNavigation { get; set; }
}
