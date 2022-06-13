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
            gestor.NewReservaRT();
        }
        public void HabilitarPantallaReservaRT()
        {
            gestor = new GestorReservaTurnoRT(this);
        }
        public void PedirSeleccionTipoRT(DataTable dt)
        {
            cmbTipoRT.DataSource = dt;
            cmbTipoRT.DisplayMember = "NombreTipo";
            cmbTipoRT.ValueMember = "TipoRT";
        }
        public void TomarSeleccionTipoRT(object sender, EventArgs e)
        {
            try
            {
                gestor.TipoRTSeleccionado((TipoRT)cmbTipoRT.SelectedValue);
            }
            catch
            {
            }
        }
        public void PedirSeleccionRT(List<DatosRT> datos)
        {
            DataTable dta = new DataTable();
            dta.Columns.Add("nroInventario", typeof(int));
            dta.Columns.Add("estado", typeof(string));
            dta.Columns.Add("ci", typeof(string));
            dta.Columns.Add("marca", typeof(string));
            dta.Columns.Add("modelo", typeof(string));
            foreach (DatosRT rt in datos)
            {
                dta.Rows.Add(rt.nroInventario,rt.estado,rt.ci,rt.marca,rt.modelo);
            }
            tablaRT.DataSource = dta;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
