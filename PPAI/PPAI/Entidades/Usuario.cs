using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string? clave { get; set; }
        public string nombreUsuario { get; set; }
        public bool? habilitado { get; set; }
        public PersonalCientifico? personalCientifico { get; set; }

        /// <summary>
        /// Crea un Usuario con todos sus datos
        /// </summary>
        /// <param name="nom">Nombre del usuario</param>
        /// <param name="cien">Personal científico al que pertenece el Usuario</param>
        public Usuario(string nom, PersonalCientifico cien)
        {
            nombreUsuario = nom;
            habilitado = true;
            personalCientifico = cien;
        }
        
        /// <summary>
        /// Devuelve el Nombre de Usuario
        /// </summary>
        /// <returns>string, nombre del usuario</returns>
        public string getNombre()
        {
            return nombreUsuario;
        }

        /// <summary>
        /// Devuelve el PersonalCientifico al que pertenece el Usuario
        /// </summary>
        /// <returns>PersonalCientifico al que pertenece</returns>
        public PersonalCientifico obtenerCientifico()
        {
            return personalCientifico;
        }
    }
}
