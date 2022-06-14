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
        GestorReservaTurnoRT gestor;
        DatosRT rec;

        public PantallaTurno(List<DatosTurno> datos, GestorReservaTurnoRT gest, Sesion sesion, DatosRT rt)
        {
            InitializeComponent();
            gestor = gest;
            turnos = datos;
            calendario.MinDate = fechaSeleccion;
            rec = rt;
            lblNroInv.Text += rt.nroInventario.ToString();
            lblCentro.Text = rt.ci;
            lblMarca.Text += rt.marca;
            lblMod.Text += rt.modelo;
            lblUsuario.Text = sesion.getNombreUsuario();
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
                btnConfirmar.Enabled = true;
            }
            catch
            {
                lblDia.Text = "Día: ".PadRight(10);
                lblFechaGen.Text = "Fecha: ".PadRight(10);
                lblInicio.Text = "Inicio: ".PadRight(10);
                lblFin.Text = "Fin: ".PadRight(10);
                btnConfirmar.Enabled = false;
            }
        }

        private void ConfirmarReserva(object sender, EventArgs e)
        {
            Turno turno = (Turno)cmbTurnos.SelectedValue;
            gestor.ReservarTurnoRT(turno, rec);
            DatosTurno datostur = turno.MostrarTurno();
            string mensaje = "Recurso:\n" + rec.ci + "\nNumero: " + rec.nroInventario.ToString() + "\nMarca: " + rec.marca + "\nModelo: " + rec.modelo;
            var culture = new System.Globalization.CultureInfo("es-ES");
            string dia = culture.DateTimeFormat.GetDayName(datostur.fechaHoraInicio.DayOfWeek);
            mensaje += "\n\nTurno:\n" + "Fecha: " + DateOnly.FromDateTime(datostur.fechaHoraInicio).ToString() + "\nDía: " + dia[0].ToString().ToUpper() + dia.Substring(1, dia.Length - 1) + "\nInicio: " + datostur.fechaHoraInicio.TimeOfDay.ToString() + "\nFin: " + datostur.fechaHoraInicio.TimeOfDay.ToString();
            MessageBox.Show(mensaje, "Turno Reservado");
        }
    }
}
