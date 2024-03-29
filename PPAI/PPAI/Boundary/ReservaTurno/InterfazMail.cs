﻿using PPAI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI.Boundary.ReservaTurno
{
    internal class InterfazMail : IObserverTurno
    {
        private string apistr = "https://maker.ifttt.com/trigger/turno_mail/with/key/itmBisW0tDS4fwc2viUCwaE4wiaQbbhxUC0mc1SCuE_?";

        /// <summary>
        /// Enviar notificación a través de mail
        /// </summary>
        /// <param name="numero">Número de teléfono, cumple con la interfaz observer, no se ua en InterfazMail</param>
        /// <param name="mail">Dirección de correo electrónico a la cual enviar</param>
        /// <param name="recurso">Nombre y número de inventario del recurso</param>
        /// <param name="turno">Fecha y horario de inicio y fin del turno</param>
        public void notificar(string numero, string mail, string recurso, string turno)
        {
            generarMail(mail, recurso, turno);
        }

        /// <summary>
        /// Genera el correo a ser enviado y lo envía
        /// </summary>
        /// <param name="medio">Número al cual enviar el mensaje</param>
        /// <param name="recurso">Nombre y número de inventario del recurso</param>
        /// <param name="turno">Fecha y horario de inicio y fin del turno</param>
        private void generarMail(string medio, string recurso, string turno)
        {
            string subject = "Turno para " + recurso + " confirmado";
            string body = "Su turno fue reservado exitosamente.<br><b>Recurso:</b> " + recurso + "<br><b>Turno:</b> " + turno;
            string args = "value1=" + medio + "&value2=" + subject + "&value3=" + body;
            string full = apistr + args;
            var client = new HttpClient();
            var resp = client.GetAsync(full);
        }
    }
}
