using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class PersonalCientifico
    {
        private int legajo;
        private string nombre;
        private string apellido;
        private int nroDocumento;
        private string correoInstitucional;
        private string correoPersonal;
        private string telefono;
        private List<Turno> turnos = new List<Turno>();
        //private Usuario usuario;

        public PersonalCientifico(int leg, string nom, string ape, int doc, string mins, string mper, string tel)
        {
            legajo = leg;
            nombre = nom;
            apellido = ape;
            nroDocumento = doc;
            correoInstitucional = mins;
            correoPersonal = mper;
            telefono = tel;
        }

        public void SetTurno(Turno tur)
        {
            turnos.Add(tur);
        }

        public string tomarCorreoPersonal()
        {
            return correoPersonal;
        }
        public string tomarCorreoInstitucional()
        {
            return correoInstitucional;
        }
    }
}
