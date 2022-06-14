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
using PPAI.Menu;

namespace PPAI.ReservaTurnoRT
{
    public partial class PantallaReservaTurnoRT : Form
    {
        private GestorReservaTurnoRT? gestor;
        private Sesion? actual;
        private MenuPrincipal principal;
        public PantallaReservaTurnoRT(Sesion sesion, MenuPrincipal menu, GestorReservaTurnoRT ges)
        {
            principal = menu;
            gestor = ges;
            actual = sesion;
            InitializeComponent();
            HabilitarPantallaReservaRT();
            gestor.setPantalla(this);
            gestor.NewReservaRT();
        }
        public void HabilitarPantallaReservaRT()
        {
            lblUsuario.Text = actual.getNombreUsuario();
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
                gestor.TipoRTSeleccionado(null);
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
            dta.Columns.Add("rt", typeof(RecursoTecnologico));
            foreach (DatosRT rt in datos)
            {
                dta.Rows.Add(rt.nroInventario,rt.estado,rt.ci,rt.marca,rt.modelo, rt.rt);
            }
            tablaRT.DataSource = dta;
        }

        private void TomarSeleccionRT(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RecursoTecnologico rt = (RecursoTecnologico)tablaRT.Rows[e.RowIndex].Cells["Recurso"].Value;
                gestor.TomarSeleccionRT(rt);
            }
            catch
            {
            }
        }
        public void PedirSeleccionDeTurno(List<DatosTurno> turnos, DatosRT rt)
        {
            PantallaTurno pt = new PantallaTurno(turnos, gestor, actual, rt, principal);
            this.Hide();
            var result = pt.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Show();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            principal.Show();
            this.Close();
        }
    }
}
