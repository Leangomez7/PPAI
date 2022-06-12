using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class PersonalCientifico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int nroDocumento;
        private string correoInstitucional;
        private string correoPersonal;
        private int telefono;
        private Usuario usuario;

        public PersonalCientifico mostrarPersonalCientifico()
        {
            return this;
        }
        public void inhabilitarUsuario()
        {
            this.usuario.inhabilitar();
        }
        public void habilitarUsuario()
        {
            this.usuario.habilitar();
        }
        public void mostrarMisNovedades()
        {
            //
        }
        public bool tengoUsuarioHabilitado()
        {
            return usuario.esHabilitado();
        }
        public string tomarCorreoPersonal()
        {
            return correoPersonal;
        }
        public string tomarCorreoInstitucional()
        {
            return correoInstitucional;
        }
        public bool esTuUsuario(Usuario user)
        {
            if (usuario == user)
            {
                return true;
            }
            return false;
        }
    }
}
