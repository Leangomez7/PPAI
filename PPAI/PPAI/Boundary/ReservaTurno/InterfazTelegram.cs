using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using PPAI.Entidades;

namespace PPAI.Boundary.ReservaTurno
{
    public class InterfazTelegram : IObserverTurno
    {
        private string apistr = "https://api.telegram.org/bot5693847010:AAHkUssqcQ5AW2aRGCe6vSii1i5I-RiJvaQ/sendMessage?";

        public void notificar(string numero, string mail, string recurso, string turno)
        {
            generarMensaje(numero, recurso, turno);
        }
        private void generarMensaje(string medio, string recurso, string turno)
        {
            string text = "Su turno para <b>" + recurso + "</b> ha sido reservado exitosamente\n<b>Turno:</b> " + turno;
            string args = "chat_id=" + medio + "&text=" + text + "&parse_mode=HTML";
            string full = apistr + args;
            var client = new HttpClient();
            var resp = client.GetAsync(full);
        }
    }
}
