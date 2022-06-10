using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Usuario
    {
        public string clave;
        public string nombreUsuario;
        public bool habilitado;

        public void habilitar()
        {
            this.habilitado = true;
        }
        public void inhabilitar()
        {
            this.habilitado = false;
        }
        public void modificarPassword(string claveNueva)
        {
            this.clave = claveNueva;
        }
        /*
        public PersonalCientifico obtenerCientifico()
        {
            //
        }
        */
    }
}
