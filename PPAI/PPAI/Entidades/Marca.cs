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

        public Marca(string nom)
        {
            nombre = nom;
            modelos = new List<Modelo>();
        }
        public string MostrarMarca()
        {
            return nombre;
        }
        public string[] MostrarMisModelos()
        {
            List<string> listaModelos = new();
            foreach(Modelo modelo in modelos)
            {
                listaModelos.Add(modelo.MostrarModelo());
            }
            return listaModelos.ToArray();
        }
    }
}
