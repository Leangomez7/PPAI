using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class TipoRT
    {
        private string nombre;
        private string descripcion;
        private List<Caracteristicas> caracteristicas;

        public TipoRT(string nom, string des)
        {
            nombre = nom;
            descripcion = des;
        }
        public string getNombreTipoRecurso()
        {
            return nombre;
        }

    }
}
