using PPAI.Entidades;
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

        public void notificar(PersonalCientifico medio, string recurso, string turno)
        {
            generarNotificacion(medio.tomarCorreoInstitucional(), recurso, turno);
        }
        private void generarNotificacion(string medio, string recurso, string turno)
        {
            string subject = "Turno para " + recurso + " confirmado";
            string body = "Su turno fue reservado exitosamente.<br><b>Recurso:</b> " + recurso + "<br><b>Turno:</b> " + turno;
            string args = "value1=" + medio + "&value2=" + subject + "&value3=" + body;
            string full = apistr + args;
            var client = new HttpClient();
            System.Diagnostics.Debug.WriteLine(full);
            var resp = client.GetAsync(full);
            resp.Wait();
            System.Diagnostics.Debug.WriteLine(resp.Result.ToString());
        }
    }
}
