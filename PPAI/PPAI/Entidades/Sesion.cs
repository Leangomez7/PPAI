using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class Sesion
    {
        [Key]
        public int id { get; set; }
        public DateTime fechaDesde { get; set; } = DateTime.Now;
        public DateTime fechaHasta { get; set; } = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
        public Usuario usuario { get; set; }

        /// <summary>
        /// Crea una nueva Sesión con un Usuario
        /// </summary>
        /// <param name="user">Usuario que inició la sesión</param>
        public Sesion(Usuario user)
        {
            usuario = user;
        }

        /// <summary>
        /// Devuelve un string con el nombre de usuario de la sesión
        /// </summary>
        /// <returns>Nombre de usuario loggeado</returns>
        public string getNombreUsuario()
        {
            return usuario.getNombre();
        }

        /// <summary>
        /// Devuelve el Personal Cientifico loggeado con su usuario
        /// </summary>
        /// <returns>PersonalCientifico Loggeado</returns>
        public PersonalCientifico ObtenerCientificoLoggeado()
        {
            return usuario.obtenerCientifico();
        }
    }
}
