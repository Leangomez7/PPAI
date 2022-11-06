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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbTipoRT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaRT = new System.Windows.Forms.DataGridView();
            this.Col3NroInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col1CI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRT)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Black;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(641, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(105, 30);
            this.lblUsuario.TabIndex = 7;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Image = global::PPAI.Properties.Resources.userIconBlanco;
            this.pictureBox3.Location = new System.Drawing.Point(605, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::PPAI.Properties.Resources.logoGrande;
            this.pictureBox2.Location = new System.Drawing.Point(21, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(238, 96);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(-11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(816, 96);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // cmbTipoRT
            // 
            this.cmbTipoRT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRT.FormattingEnabled = true;
            this.cmbTipoRT.Location = new System.Drawing.Point(12, 139);
            this.cmbTipoRT.Name = "cmbTipoRT";
            this.cmbTipoRT.Size = new System.Drawing.Size(121, 23);
            this.cmbTipoRT.TabIndex = 8;
            this.cmbTipoRT.SelectedIndexChanged += new System.EventHandler(this.TomarSeleccionTipoRT);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Seleccionar tipo de recurso tecnológico";
            // 
            // tablaRT
            // 
            this.tablaRT.AllowUserToAddRows = false;
            this.tablaRT.AllowUserToDeleteRows = false;
            this.tablaRT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaRT.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tablaRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaRT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col3NroInventario,
            this.col6Estado,
            this.Col1CI,
            this.col4Marca,
            this.col5Modelo,
            this.Recurso});
            this.tablaRT.Location = new System.Drawing.Point(12, 168);
            this.tablaRT.Name = "tablaRT";
            this.tablaRT.ReadOnly = true;
            this.tablaRT.RowTemplate.Height = 25;
            this.tablaRT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaRT.Size = new System.Drawing.Size(638, 251);
            this.tablaRT.TabIndex = 10;
            this.tablaRT.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TomarSeleccionRT);
            // 
            // Col3NroInventario
            // 
            this.Col3NroInventario.DataPropertyName = "nroInventario";
            this.Col3NroInventario.FillWeight = 17.07051F;
            this.Col3NroInventario.HeaderText = "Numero";
            this.Col3NroInventario.MinimumWidth = 60;
            this.Col3NroInventario.Name = "Col3NroInventario";
            this.Col3NroInventario.ReadOnly = true;
            // 
            // col6Estado
            // 
            this.col6Estado.DataPropertyName = "estado";
            this.col6Estado.FillWeight = 9.119678F;
            this.col6Estado.HeaderText = "Estado";
            this.col6Estado.MinimumWidth = 60;
            this.col6Estado.Name = "col6Estado";
            this.col6Estado.ReadOnly = true;
            // 
            // Col1CI
            // 
            this.Col1CI.DataPropertyName = "ci";
            this.Col1CI.FillWeight = 167.2346F;
            this.Col1CI.HeaderText = "CI";
            this.Col1CI.MinimumWidth = 200;
            this.Col1CI.Name = "Col1CI";
            this.Col1CI.ReadOnly = true;
            // 
            // col4Marca
            // 
            this.col4Marca.DataPropertyName = "marca";
            this.col4Marca.FillWeight = 76.53896F;
            this.col4Marca.HeaderText = "Marca";
            this.col4Marca.MinimumWidth = 40;
            this.col4Marca.Name = "col4Marca";
            this.col4Marca.ReadOnly = true;
            // 
            // col5Modelo
            // 
            this.col5Modelo.DataPropertyName = "modelo";
            this.col5Modelo.FillWeight = 106.9906F;
            this.col5Modelo.HeaderText = "Modelo";
            this.col5Modelo.MinimumWidth = 60;
            this.col5Modelo.Name = "col5Modelo";
            this.col5Modelo.ReadOnly = true;
            // 
            // Recurso
            // 
            this.Recurso.DataPropertyName = "rt";
            this.Recurso.HeaderText = "Recurso";
            this.Recurso.Name = "Recurso";
            this.Recurso.ReadOnly = true;
            this.Recurso.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(697, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // PantallaReservaTurnoRT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tablaRT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipoRT);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "PantallaReservaTurnoRT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservar turno recurso tecnologico";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUsuario;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private ComboBox cmbTipoRT;
        private Label label1;
        private DataGridView tablaRT;
        private Button btnCancelar;
        private DataGridViewTextBoxColumn Col3NroInventario;
        private DataGridViewTextBoxColumn col6Estado;
        private DataGridViewTextBoxColumn Col1CI;
        private DataGridViewTextBoxColumn col4Marca;
        private DataGridViewTextBoxColumn col5Modelo;
        private DataGridViewTextBoxColumn Recurso;
    }
}