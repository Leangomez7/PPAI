using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Usuario
    {
        private string? clave;
        private string nombreUsuario;
        private bool? habilitado;
        private PersonalCientifico? personalCientifico;
        
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
