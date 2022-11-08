using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI.Boundary.ReservaTurno;
using PPAI.Control;
using PPAI.Entidades;
using PPAI.Menu;

namespace PPAI.ReservaTurnoRT
{
    public partial class PantallaTurno : Form
    {
        // Fecha actual
        DateTime fechaSeleccion = DateTime.Today;

        // Lista de datos de los turnos
        List<DatosTurno> turnos;

        // Gestor Reserva Turno
        GestorReservaTurnoRT gestor;

        // Datos de los turnos
        DatosRT rec;

        // Objeto menu
        MenuPrincipal menu;

        public PantallaTurno(List<DatosTurno> datos, GestorReservaTurnoRT gest, Sesion sesion, DatosRT rt, MenuPrincipal men)
        {
            InitializeComponent();
            gestor = gest;
            menu = men;
            turnos = datos;
            calendario.MinDate = fechaSeleccion;
            rec = rt;
            lblNroInv.Text += rt.nroInventario.ToString();
            lblCentro.Text = rt.ci;
            lblMarca.Text += rt.marca;
            lblMod.Text += rt.modelo;
            lblUsuario.Text = sesion.getNombreUsuario();
            lblFechaHora.Text = "Turnos posteriores a " + DateOnly.FromDateTime(DateTime.Now).ToString();
        }

        /// <summary>
        /// Seleccion de una fecha del calendario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TomarSeleccionFecha(object sender, DateRangeEventArgs e)
        {
            fechaSeleccion = e.Start;
            MostrarTurnosFecha(fechaSeleccion);
        }

        /// <summary>
        /// Muestra los turnos existentes para una fecha dada
        /// </summary>
        /// <param name="fechaSeleccion"> Una fecha seleccionada por el usuario </param>
        public void MostrarTurnosFecha(DateTime fechaSeleccion)
        {
            DataTable dta = new DataTable();
            dta.Columns.Add("horario", typeof(string));
            dta.Columns.Add("turno", typeof(Turno));
            foreach (DatosTurno datosTurno in turnos)
            {
                if (datosTurno.fechaHoraInicio.Date == fechaSeleccion.Date)
                {
                    string horarios = datosTurno.fechaHoraInicio.ToString("HH:mm") + " - " + datosTurno.fechaHoraFin.ToString("HH:mm");
                    dta.Rows.Add(horarios, datosTurno.turno);
                }
            }
            if (dta.Rows.Count > 0)
            {
                cmbTurnos.DisplayMember = "horario";
                cmbTurnos.DataSource = dta;
                cmbTurnos.ValueMember = "turno";
            }
            else
            {
                DataRow fila = dta.NewRow();
                fila["horario"] = "No existen turnos";
                fila["turno"] = null;
                dta.Rows.InsertAt(fila, 0);
                cmbTurnos.DisplayMember = "horario";
                cmbTurnos.ValueMember = "turno";
                cmbTurnos.DataSource = dta;
            }
        }

        /// <summary>
        /// Muestra los datos del turno seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TomarSeleccionTurno(object sender, EventArgs e)
        {
            try
            {
                var culture = new System.Globalization.CultureInfo("es-ES");
                if (cmbTurnos.SelectedValue != null)
                {
                    Turno tur = (Turno)cmbTurnos.SelectedValue;
                    DatosTurno datos = tur.MostrarTurno();
                    string dia = culture.DateTimeFormat.GetDayName(datos.fechaHoraInicio.DayOfWeek);
                    lblDia.Text = "Día: ".PadRight(10) + dia[0].ToString().ToUpper() + dia.Substring(1, dia.Length - 1);
                    lblFechaGen.Text = "Fecha: ".PadRight(10) + DateOnly.FromDateTime(datos.fechaHoraInicio).ToString();
                    lblInicio.Text = "Inicio: ".PadRight(10) + datos.fechaHoraInicio.ToString("HH:mm");
                    lblFin.Text = "Fin: ".PadRight(10) + datos.fechaHoraFin.ToString("HH:mm");
                    btnConfirmar.Enabled = verificarCampos();
                }
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

        /// <summary>
        /// Solicita la confirmación de la reserva del turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmarReserva(object sender, EventArgs e)
        {
            Turno turno = (Turno)cmbTurnos.SelectedValue;
            DatosTurno datostur = turno.MostrarTurno();
            string mensaje = "Recurso:\n" + rec.ci + "\nNumero: " + rec.nroInventario.ToString() + "\nMarca: " + rec.marca + "\nModelo: " + rec.modelo;
            var culture = new System.Globalization.CultureInfo("es-ES");
            string dia = culture.DateTimeFormat.GetDayName(datostur.fechaHoraInicio.DayOfWeek);
            mensaje += "\n\nTurno:\n" + "Fecha: " + datostur.fechaHoraInicio.ToString("dd/MM/yyyy") + "\nDía: " + dia[0].ToString().ToUpper() + dia.Substring(1, dia.Length - 1) + 
                "\nInicio: " + datostur.fechaHoraInicio.ToString("HH:mm") + "\nFin: " + datostur.fechaHoraFin.ToString("HH:mm");
            
            if (MessageBox.Show(mensaje, "Turno Reservado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<int> medios = new List<int>();
                if (chWhatsApp.Checked)
                {
                    medios.Add((int)Medio.WhatsApp);
                }
                if (chMail.Checked)
                {
                    medios.Add((int)Medio.Mail);
                }
                gestor.ReservarTurnoRT(turno, rec, medios);
                FinCU();
            }
        }

        /// <summary>
        /// Verifica que se haya seleccionado al menos un tipo de notificación y algún turno
        /// </summary>
        /// <returns>
        /// true si se seleccionó algún tipo de notificación y algún turno
        /// </returns>
        public bool verificarCampos()
        {
            if (chMail.Checked == true || chWhatsApp.Checked == true)
            {
                try
                {
                    Turno xd = (Turno)cmbTurnos.SelectedValue;
                    if (xd is not null)
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Cancela la reserva del turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Activa o desactiva el botón confirmar de acuerdo al método verificarCampos()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chMail_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = verificarCampos();
        }

        /// <summary>
        /// Activa o desactiva el botón confirmar de acuerdo al método verificarCampos()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chWhatsApp_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = verificarCampos();
        }

        /// <summary>
        /// Informa al usuario que el turno se reservó exitosamente
        /// </summary>
        private void FinCU()
        {
            MessageBox.Show("Turno reservado exitosamente", "Turno Reservado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            menu.Show();
            this.Close();
            DialogResult = DialogResult.OK;
        }
    }
}
