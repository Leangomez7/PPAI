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

        /// <summary>
        /// Crea un Personal Científico nuevo
        /// </summary>
        /// <param name="leg">Legajo</param>
        /// <param name="nom">Nombre</param>
        /// <param name="ape">Apellido</param>
        /// <param name="doc">Número de Documento</param>
        /// <param name="mins">Correo institucional</param>
        /// <param name="mper">Correo personal</param>
        /// <param name="tel">Número de teléfono</param>
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

        /// <summary>
        /// Agrega un turno a la lista de Turnos del científico
        /// </summary>
        /// <param name="tur">Turno a agregar</param>
        public void SetTurno(Turno tur)
        {
            turnos.Add(tur);
        }

        /// <summary>
        /// Devuelve el correo personal del científico
        /// </summary>
        /// <returns>Correo personal</returns>
        public string tomarCorreoPersonal()
        {
            return correoPersonal;
        }
        /// <summary>
        /// Devuelve el correo institucional del científico
        /// </summary>
        /// <returns>Correo institucional</returns>
        public string tomarCorreoInstitucional()
        {
            return correoInstitucional;
        }

        public string tomarTelefono()
        {
            return telefono;
        }
    }
}
