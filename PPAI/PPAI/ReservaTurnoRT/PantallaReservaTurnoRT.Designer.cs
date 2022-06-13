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
            this.Col1CI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2NombreRecurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3NroInventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cmbTipoRT.FormattingEnabled = true;
            this.cmbTipoRT.Location = new System.Drawing.Point(12, 139);
            this.cmbTipoRT.Name = "cmbTipoRT";
            this.cmbTipoRT.Size = new System.Drawing.Size(121, 23);
            this.cmbTipoRT.TabIndex = 8;
            this.cmbTipoRT.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.tablaRT.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tablaRT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaRT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col1CI,
            this.col2NombreRecurso,
            this.Col3NroInventario,
            this.col4Marca,
            this.col5Modelo,
            this.col6Estado});
            this.tablaRT.Location = new System.Drawing.Point(12, 168);
            this.tablaRT.Name = "tablaRT";
            this.tablaRT.RowTemplate.Height = 25;
            this.tablaRT.Size = new System.Drawing.Size(638, 251);
            this.tablaRT.TabIndex = 10;
            // 
            // Col1CI
            // 
            this.Col1CI.HeaderText = "CI";
            this.Col1CI.Name = "Col1CI";
            // 
            // col2NombreRecurso
            // 
            this.col2NombreRecurso.HeaderText = "Nombre";
            this.col2NombreRecurso.Name = "col2NombreRecurso";
            // 
            // Col3NroInventario
            // 
            this.Col3NroInventario.HeaderText = "NroInventario";
            this.Col3NroInventario.Name = "Col3NroInventario";
            // 
            // col4Marca
            // 
            this.col4Marca.HeaderText = "Marca";
            this.col4Marca.Name = "col4Marca";
            // 
            // col5Modelo
            // 
            this.col5Modelo.HeaderText = "Modelo";
            this.col5Modelo.Name = "col5Modelo";
            // 
            // col6Estado
            // 
            this.col6Estado.HeaderText = "Estado";
            this.col6Estado.Name = "col6Estado";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(671, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
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
        private DataGridViewTextBoxColumn Col1CI;
        private DataGridViewTextBoxColumn col2NombreRecurso;
        private DataGridViewTextBoxColumn Col3NroInventario;
        private DataGridViewTextBoxColumn col4Marca;
        private DataGridViewTextBoxColumn col5Modelo;
        private DataGridViewTextBoxColumn col6Estado;
        private Button btnCancelar;
    }
}