using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI.Entidades;

namespace PPAI.ReservaTurnoRT
{
    public partial class PantallaTurno : Form
    {
        DateTime fechaSeleccion = DateTime.Today;
        List<DatosTurno> turnos;

        public PantallaTurno(List<DatosTurno> datos, GestorReservaTurnoRT gestor, Sesion sesion)
        {
            InitializeComponent();
            turnos = datos;
            calendario.MinDate = fechaSeleccion;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TomarSeleccionFecha(object sender, DateRangeEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(e.Start.ToString() + " " + e.End.ToString() + " " + e.Start.GetType());
            fechaSeleccion = e.Start;
            MostrarTurnosFecha(fechaSeleccion);
        }

        public void MostrarTurnosFecha(DateTime fechaSeleccion)
        {
            DataTable dta = new DataTable();
            dta.Columns.Add("horario", typeof(string));
            dta.Columns.Add("turno", typeof(Turno));
            foreach (DatosTurno datosTurno in turnos)
            {
                if (datosTurno.fechaHoraInicio.Date == fechaSeleccion.Date)
                {
                    string horarios = datosTurno.fechaHoraInicio.TimeOfDay.ToString() + " - " + datosTurno.fechaHoraFin.TimeOfDay.ToString();
                    dta.Rows.Add(horarios, datosTurno.turno);
                }
            }
            if (dta.Rows.Count > 0)
            {
                cmbTurnos.DataSource = dta;
                cmbTurnos.DisplayMember = "horario";
                cmbTurnos.ValueMember = "turno";
            }
            else
            {
                DataRow fila = dta.NewRow();
                fila["horario"] = "No existen turnos";
                fila["turno"] = null;
                dta.Rows.InsertAt(fila, 0);
                cmbTurnos.DataSource = dta;
                cmbTurnos.DisplayMember = "horario";
                cmbTurnos.ValueMember = "turno";
            }
        }

        private void TomarSeleccionTurno(object sender, EventArgs e)
        {
            try
            {
                var culture = new System.Globalization.CultureInfo("es-ES");
                Turno tur = (Turno)cmbTurnos.SelectedValue;
                DatosTurno datos = tur.MostrarTurno();
                string dia = culture.DateTimeFormat.GetDayName(datos.fechaHoraInicio.DayOfWeek);
                lblDia.Text = "Día: ".PadRight(10) + dia[0].ToString().ToUpper()+dia.Substring(1,dia.Length-1);
                lblFechaGen.Text = "Fecha: ".PadRight(10) + DateOnly.FromDateTime(datos.fechaHoraInicio).ToString();
                lblInicio.Text = "Inicio: ".PadRight(10) + datos.fechaHoraInicio.TimeOfDay.ToString();
                lblFin.Text = "Fin: ".PadRight(10) + datos.fechaHoraFin.TimeOfDay.ToString();
            }
            catch
            {
                lblDia.Text = "Día: ".PadRight(10);
                lblFechaGen.Text = "Fecha: ".PadRight(10);
                lblInicio.Text = "Inicio: ".PadRight(10);
                lblFin.Text = "Fin: ".PadRight(10);
            }
        }
    }
}
