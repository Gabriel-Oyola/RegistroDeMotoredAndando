using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPracticaII.Shared
{
    public class Motocicleta
    {
        public int IdUsuario { get; set; }
        public int IdMoto { get; set; }

        public string Patente { get; set; } 

        public string Marca { get; set; } 

        public string Modelo { get; set; }

        public int anio { get; set; }

        public int Aseguradora { get; set; }
    }
}
