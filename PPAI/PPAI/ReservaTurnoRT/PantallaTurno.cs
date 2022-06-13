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
        public PantallaTurno(List<DatosTurno> turnos, GestorReservaTurnoRT gestor, Sesion sesion)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
