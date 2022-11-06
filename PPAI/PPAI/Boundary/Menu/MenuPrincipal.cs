using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PPAI.ReservaTurnoRT;
using PPAI.Entidades;
using PPAI.Control;

namespace PPAI.Menu
{
    public partial class MenuPrincipal : Form
    {
        private Sesion actual;
        private GestorReservaTurnoRT gestor;

        public MenuPrincipal(Sesion iniciar)
        {
            actual = iniciar;
            InitializeComponent();
            lblUsuario.Text = actual.getNombreUsuario();
            gestor = new GestorReservaTurnoRT(actual);
        }

        /// <summary>
        /// Permite dar comienzo al caso de uso Reservar turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opcionReservarTurnoRT(object sender, EventArgs e)
        {
            PantallaReservaTurnoRT pantallaReservaTurnoRT = new PantallaReservaTurnoRT(actual, this, gestor);
            pantallaReservaTurnoRT.Show();
            this.Hide();
        }
    }
}
