using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class Marca
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Modelo> modelos { get; set; }

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
