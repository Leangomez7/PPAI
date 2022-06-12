﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Entidades
{
    internal class CambioEstadoRT
    {
        private DateTime fechaHoraDesde;
        private DateTime fechaHoraHasta;
        private Estado estado;

        public CambioEstadoRT(Estado est)
        {
            fechaHoraDesde = DateTime.Now;
            estado = est;
        }
        public DateTime getFechaHoraDesde()
        {
            return fechaHoraDesde;
        }
        public DateTime getFechaHoraHasta()
        {
            return fechaHoraHasta;
        }
        public Estado getEstado()
        {
            return estado;
        }
    }
}
