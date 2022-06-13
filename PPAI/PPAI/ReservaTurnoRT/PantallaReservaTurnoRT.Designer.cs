namespace PPAI.ReservaTurnoRT
{
    partial class PantallaReservaTurnoRT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaReservaTurnoRT));
            this.cmbTipoRT = new System.Windows.Forms.ComboBox();
            this.tablaRT = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRT)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTipoRT
            // 
            this.cmbTipoRT.FormattingEnabled = true;
            this.cmbTipoRT.Location = new System.Drawing.Point(12, 12);
            this.cmbTipoRT.Name = "cmbTipoRT";
            this.cmbTipoRT.Size = new System.Drawing.Size(121, 23);
            this.cmbTipoRT.TabIndex = 0;
            this.cmbTipoRT.SelectedIndexChanged += new System.EventHandler(this.TomarSeleccionTipoRT);
            // 
            // tablaRT
            // 
            this.tablaRT.AllowUserToAddRows = false;
            this.tablaRT.AllowUserToDeleteRows = false;
            this.tablaRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaRT.Location = new System.Drawing.Point(12, 41);
            this.tablaRT.Name = "tablaRT";
            this.tablaRT.ReadOnly = true;
            this.tablaRT.RowTemplate.Height = 25;
            this.tablaRT.Size = new System.Drawing.Size(608, 315);
            this.tablaRT.TabIndex = 1;
            // 
            // PantallaReservaTurnoRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tablaRT);
            this.Controls.Add(this.cmbTipoRT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PantallaReservaTurnoRT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservar turno recurso tecnologico";
            ((System.ComponentModel.ISupportInitialize)(this.tablaRT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cmbTipoRT;
        private DataGridView tablaRT;
    }
}