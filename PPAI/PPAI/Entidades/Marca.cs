using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Marca
    {
        private string nombre;
        private List<Modelo> modelos;

        /// <summary>
        /// Crea una Marca de Recurso Tecnológico nueva
        /// </summary>
        /// <param name="nom">Nombre de la marca a crear</param>
        public Marca(string nom)
        {
            nombre = nom;
            modelos = new List<Modelo>();
        }

        /// <summary>
        /// Devuelve el nombre de la marca
        /// </summary>
        /// <returns>Un string, nombre de la marca</returns>
        public string MostrarMarca()
        {
            return nombre;
        }
    }
}
