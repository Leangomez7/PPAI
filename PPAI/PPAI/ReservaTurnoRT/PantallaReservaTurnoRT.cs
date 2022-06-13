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
    public partial class PantallaReservaTurnoRT : Form
    {
        private GestorReservaTurnoRT? gestor;
        public PantallaReservaTurnoRT()
        {
            InitializeComponent();
            HabilitarPantallaReservaRT();
        }
        public void HabilitarPantallaReservaRT()
        {
            gestor = new GestorReservaTurnoRT(this);
        }
        public void PedirSeleccionTipoRT(DataTable dt)
        {
            cmbTipoRT.DataSource = dt;
            cmbTipoRT.DisplayMember = "NombreTipoRT";
            cmbTipoRT.ValueMember = "TipoRT";
            cmbTipoRT.SelectedIndex = -1;
        }
        public void TomarSeleccionTipoRT(object sender, EventArgs e)
        {
            gestor.TipoRTSeleccionado((TipoRT)cmbTipoRT.SelectedValue);
        }
        public void PedirSeleccionRT(List<DatosRT> datos)
        {
           tablaRT.DataSource = datos;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
