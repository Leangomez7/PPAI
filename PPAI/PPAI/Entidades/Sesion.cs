using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Sesion
    {
        private DateTime fechaDesde = DateTime.Now;
        private DateTime? fechaHasta;
        private Usuario usuario;

        public Sesion(Usuario user)
        {
            usuario = user;
        }

        public string getNombreUsuario()
        {
            return usuario.getNombre();
        }

        public Sesion mostrarSesion()
        {
            return this;
        }
        public PersonalCientifico ObtenerCientificoLoggeado()
        {
            return usuario.obtenerCientifico();
        }
        
    }
}
