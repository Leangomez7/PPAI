using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class Modelo
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public Marca? marca { get; set; }

        /// <summary>
        /// Crea un Modelo de Recurso Tecnológico nuevo
        /// </summary>
        /// <param name="nom">Nombre del modelo</param>
        
        public Modelo()
        {

        }

        public Modelo(string nom)
        {
            nombre = nom;
        }
        /// <summary>
        /// Crea un Modelo de Recurso Tecnológico nuevo con su marca
        /// </summary>
        /// <param name="nom">Nombre del modelo</param>
        /// <param name="mar">Marca del modelo</param>
        public Modelo(string nom, Marca mar)
        {
            nombre = nom;
            marca = mar;
        }

        /// <summary>
        /// Devuelve el nombre del modelo
        /// </summary>
        /// <returns>Un string, nombre del modelo</returns>
        public string MostrarModelo()
        {
            return nombre;
        }

        /// <summary>
        /// Devuelve una Lista de string con el nombre del modelo y de su marca.
        /// </summary>
        /// <returns>Una List de string con el nombre del modelo y la marca</returns>
        public List<string> MostrarMarcaYModelo()
        {
            List<string> marcaModelo = new List<string>();
            marcaModelo.Add(MostrarModelo());
            marcaModelo.Add(marca.MostrarMarca());
            return marcaModelo;
        }
    }
}
