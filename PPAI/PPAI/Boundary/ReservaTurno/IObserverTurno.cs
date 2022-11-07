using PPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Boundary.ReservaTurno
{
    public interface IObserverTurno
    {
        public void notificar(PersonalCientifico cient, string rt, string turno);

        public static IObserverTurno crear(Medio medio)
        {
            if (medio == Medio.WhatsApp)
            {
                return new InterfazTelegram();
            }
            if (medio == Medio.Mail)
            {
                return new InterfazMail();
            }
            else
            {
                return new InterfazMail();
            }
        }
    }
}
