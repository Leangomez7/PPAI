using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    public class HorarioRT
    {
        private DayOfWeek diaSemana;
        private TimeOnly horaDesde;
        private TimeOnly horaHasta;
        private DateOnly vigenciaDesde;
        private DateOnly? vigenciaHasta;

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
            horaDesde = hrd;
            horaHasta = hrh;
            vigenciaDesde = ini;
        }

        public HorarioRT(DayOfWeek dia)
        {
            diaSemana = dia;
            horaDesde = new TimeOnly(7, 30);
            horaHasta = new TimeOnly(20, 30);
            vigenciaDesde = DateOnly.FromDateTime(DateTime.Now);
        }

        public DayOfWeek GetDia()
        {
            return diaSemana;
        }

        public TimeOnly GetHoraDesde()
        {
            return horaDesde;
        }

        public TimeOnly GetHoraHasta()
        {
            return horaHasta;
        }

        public DateOnly GetVigDesde()
        {
            return vigenciaDesde;
        }

        public DateOnly? GetVigHasta()
        {
            return vigenciaHasta;
        }
    }
}
