using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class Usuario
    {
        private string clave;
        private string nombreUsuario;
        private bool habilitado;
        private PersonalCientifico personalCientifico;
        
        public PersonalCientifico obtenerCientifico()
        {
            return personalCientifico;
        }
    }
}
