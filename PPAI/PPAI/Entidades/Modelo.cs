using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Entidades;

namespace PPAI.Entidades
{
    internal class Modelo
    {
        private string nombre;
        private Marca? marca;
        public Modelo(string nom)
        {
            nombre = nom;
        }
        public string MostrarModelo()
        {
            return nombre;
        }
        public List<string> mostrarMarcaYModelo()
        {
            List<string> marcaModelo = new List<string>();
            marcaModelo.Add(MostrarModelo());
            marcaModelo.Add(marca.MostrarMarca());
            return marcaModelo;

        }
    }
}
