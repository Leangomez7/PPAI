using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class PersonalCientifico
    {
        public int legajo;
        public string nombre;
        public string apellido;
        public int nroDocumento;
        public string correoInstitucional;
        public string correoPersonal;
        public int telefono;
        public Usuario usuario;

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
            return usuario.habilitado;
        }
        public string tomarCorreo()
        {
            return correoPersonal;
        }
    }
}
