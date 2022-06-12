﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class Usuario
    {
        private string clave;
        private string nombreUsuario;
        private bool habilitado;
        private PersonalCientifico? cientifico;
        public bool esHabilitado()
        {
            return habilitado;
        }
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
        public PersonalCientifico? obtenerCientifico()
        {
            return cientifico;
        }
    }
}
