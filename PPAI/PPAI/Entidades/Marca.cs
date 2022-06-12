using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class Marca
    {
        private string nombre;
        private List<Modelo> modelos;

        public string MostrarMarca()
        {
            return nombre;
        }
    }
}
