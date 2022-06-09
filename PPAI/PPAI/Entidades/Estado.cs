using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class Estado
    {
        private string nombre;
        private string descripcion;
        private string ambito;
        private bool esReservable;
        private bool esCancelable;

        public Estado(string nom, string des, string amb, bool esr, bool esc)
        {
            nombre = nom;
            descripcion = des;
            ambito = amb;
            esReservable = esr;
            esCancelable = esc;
        }

        public string MostrarEstado()
        {
            return nombre;
        }
    }
}
