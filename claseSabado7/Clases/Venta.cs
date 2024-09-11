using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace claseSabado7.Clases
{
    internal class Venta
    {
        public int Año { get; set; }
        public int Mes {  get; set; }
        public string Departamento {  get; set; }
        public int Precio {  get; set; }

        public Venta(int año, int mes, string departamento, int precio) { 
            Año = año;
            Mes = mes;
            Departamento = departamento;
            Precio = precio;
        }
    }
}
