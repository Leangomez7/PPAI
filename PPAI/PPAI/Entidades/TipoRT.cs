using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class TipoRT
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        /// <summary>
        /// Crea un nuevo Tipo de Recurso Tecnológico
        /// </summary>
        /// <param name="nom">Nombre del Tipo</param>
        /// <param name="des">Descripción del Tipo</param>
        public TipoRT()
        {

        }

        public TipoRT(string nom, string des)
        {
            nombre = nom;
            descripcion = des;
        }

        /// <summary>
        /// Devuelve una string con el nombre del tipo
        /// </summary>
        /// <returns>Nombre del tipo</returns>
        public string MostrarTipoRecurso()
        {
            return nombre;
        }
    }
}
