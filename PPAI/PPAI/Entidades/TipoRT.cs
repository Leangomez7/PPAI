using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class TipoRT
    {
        private string nombre;
        private string descripcion;

        /// <summary>
        /// Crea un nuevo Tipo de Recurso Tecnológico
        /// </summary>
        /// <param name="nom">Nombre del Tipo</param>
        /// <param name="des">Descripción del Tipo</param>
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
