using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class AsignacionCientificoCI
    {
        [Key]
        public int id { get; set; }
        public DateTime fechaDesde { get; set; } = DateTime.Now;
        public DateTime fechaHasta { get; set; } = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
        public PersonalCientifico cientifico { get; set; }
        public List<Turno> turnos { get; set; }

        /// <summary>
        /// Constructor de objeto asignación cientifico que asigna el cientifico al atributo cientifico y crea un nuevo array de turnos
        /// </summary>
        /// <param name="cient"></param>
        public AsignacionCientificoCI(PersonalCientifico cient)
            {
                cientifico = cient;
                turnos = new List<Turno>();
            }
        /// <summary>
        /// Verifica si un cientifico posee el estado activo
        /// </summary>
        /// <param name="personalCientifico"></param>
        /// <returns>
        /// bool
        /// </returns>
        public bool esCientificoActivo(PersonalCientifico personalCientifico)
        {
            if (fechaHasta == System.Data.SqlTypes.SqlDateTime.MaxValue.Value && cientifico == personalCientifico)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega el turno al array de turnos
        /// </summary>
        /// <param name="turno"></param>
        public void setTurno(Turno turno)
        {
            turnos.Add(turno);
        }

        /// <summary>
        /// Devuelve el correo electrónico institucional del científico
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public string obtenerCorreoInstitucionalCientifico()
        {
            return cientifico.tomarCorreoInstitucional();
        }
        /// <summary>
        /// Devuelve el correo electrónico personal del científico
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public string obtenerCorreoPersonalCientifico()
        {
            return cientifico.tomarCorreoPersonal();
        }
    }
}
