using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempodeUnaCervezaDef
{
    class Cervezas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int mililitros { get; set; }
        public double gradosalcohol { get; set; }
        public Cervezas(int id, string nombre, int mililitros, double gradosalcohol)
        {
            this.id = id;
            this.nombre = nombre;
            this.mililitros = mililitros;
            this.gradosalcohol = gradosalcohol;
        }
    }
}
