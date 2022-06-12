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

namespace PPAI.Menu
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = usuario;
        }

        private void opcionReservarTurnoRT(object sender, EventArgs e)
        {
            PantallaReservaTurnoRT pantallaReservaTurnoRT = new PantallaReservaTurnoRT();
            pantallaReservaTurnoRT.Show();
            this.Hide();
        }
    }
}
