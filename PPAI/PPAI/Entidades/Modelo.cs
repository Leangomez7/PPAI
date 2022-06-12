using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class Modelo
    {
        private string nombre;
        public Modelo(string nom)
        {
            nombre = nom;
        }
        public string MostrarModelo()
        {
            return nombre;
        }
        public void mostrarMarcaYModelo()
        {
            //
        }
    }
}
