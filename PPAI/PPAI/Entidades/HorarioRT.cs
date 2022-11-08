using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PPAI.Entidades
{
    public class HorarioRT
    {
        [Key]
        public int id { get; set; }
        public DayOfWeek diaSemana { get; set; }
        public DateTime horaDesde { get; set; } = new DateTime(new TimeOnly(7, 30).Ticks);
        public DateTime horaHasta { get; set; } = new DateTime(new TimeOnly(20, 30).Ticks);
        public DateTime vigenciaDesde { get; set; } = DateTime.Now;
        public DateTime vigenciaHasta { get; set; } = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
        
        /// <summary>
        /// Crea el objeto horarioRT asginandole un diaSemana, una horaDesde, una horaHasta y una vigenciaDese desde parametro
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="hrd"></param>
        /// <param name="hrh"></param>
        /// <param name="ini"></param>
        public HorarioRT(DayOfWeek dia, TimeOnly hrd, TimeOnly hrh, DateOnly ini)
        {
            diaSemana = dia;
            horaDesde = new DateTime(hrd.Ticks);
            horaHasta = new DateTime(hrh.Ticks);
            vigenciaDesde = ini.ToDateTime(TimeOnly.MinValue);
        }

        public HorarioRT(DayOfWeek dia)
        {
            diaSemana = dia;
            horaDesde = new DateTime(new TimeOnly(7, 30).Ticks);
            horaHasta = new DateTime(new TimeOnly(20, 30).Ticks);
            vigenciaDesde = DateTime.Now;
        }

        public DayOfWeek GetDia()
        {
            return diaSemana;
        }

        public TimeOnly GetHoraDesde()
        {
            return new TimeOnly(horaDesde.Ticks);
        }

        public TimeOnly GetHoraHasta()
        {
            return new TimeOnly(horaHasta.Ticks);
        }

        public DateOnly GetVigDesde()
        {
            return DateOnly.FromDateTime(vigenciaDesde);
        }

        public DateOnly GetVigHasta()
        {
            return DateOnly.FromDateTime((DateTime)vigenciaHasta);
        }
    }
}
