using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class TipoRT
    {
        private string nombre;
        private string descripcion;

        public TipoRT(string nom, string des)
        {
            nombre = nom;
            descripcion = des;
        }
        public string MostrarTipoRecurso()
        {
            return nombre;
        }
    }
}
