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

namespace PPAI.Menu
{
    public partial class MenuPrincipal : Form
    {
        private Sesion actual;

        public MenuPrincipal(Sesion iniciar)
        {
            actual = iniciar;
            InitializeComponent();
            lblUsuario.Text = actual.getNombreUsuario();
        }

        private void opcionReservarTurnoRT(object sender, EventArgs e)
        {
            PantallaReservaTurnoRT pantallaReservaTurnoRT = new PantallaReservaTurnoRT(actual);
            pantallaReservaTurnoRT.Show();
            this.Hide();
        }
    }
}
