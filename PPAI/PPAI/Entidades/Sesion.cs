using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Sesion
    {
        public DateTime fechaDesde = DateTime.Now;
        public DateTime fechaHasta;
        public Usuario usuario;

        public Sesion mostrarSesion()
        {
            return this;
        }
        /*
        public PersonalCientifico obtenerCientificoLoggeado()
        {
            this.usuario.obtenerCientifico();
        }
        */
    }
}
