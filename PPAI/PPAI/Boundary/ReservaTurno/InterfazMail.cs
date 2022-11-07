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
        private string apistr = "https://maker.ifttt.com/trigger/turno_mail/json/with/key/itmBisW0tDS4fwc2viUCwaE4wiaQbbhxUC0mc1SCuE_?";

        public void notificar(PersonalCientifico medio, string recurso, string turno)
        {
            generarNotificacion(medio.tomarCorreoInstitucional(), recurso, turno);
        }
        private void generarNotificacion(string medio, string recurso, string turno)
        {
            string subject = "Turno para " + recurso + " confirmado";
            string body = "Su turno fue reservado exitosamente.<br><b> Recurso:</b> " + recurso + "<br><b> Turno:</b> " + turno;
            string args = "Value1=" + medio + "&Value2=" + subject + "&Value3=" + body;
            string full = apistr + args;
            var client = new HttpClient();
            Console.WriteLine(full);
            var resp = client.GetAsync(full);
            Console.WriteLine(resp.WaitAsync(TimeSpan.FromSeconds(10)).Result.Content.ToString());
        }
    }
}
