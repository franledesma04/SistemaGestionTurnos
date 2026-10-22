namespace AppWinForms
{
    partial class FrmReportes
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
            lblTitulo = new Label();
            btnPacientes = new Button();
            btnProfesionales = new Button();
            btnTurnosFecha = new Button();
            btnPendientes = new Button();
            btnHistorial = new Button();
            dtpFechaReporte = new DateTimePicker();
            lblFechaReporte = new Label();
            cboPacienteReporte = new ComboBox();
            lblPacienteReporte = new Label();
            dgvReportes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MidnightBlue;
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(508, 57);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reportes De Consultorio";
            lblTitulo.Click += label1_Click;
            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = Color.SteelBlue;
            btnPacientes.FlatStyle = FlatStyle.Flat;
            btnPacientes.ForeColor = Color.White;
            btnPacientes.Location = new Point(25, 85);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new Size(160, 40);
            btnPacientes.TabIndex = 1;
            btnPacientes.Text = "Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            btnPacientes.Click += button1_Click;
            // 
            // btnProfesionales
            // 
            btnProfesionales.BackColor = Color.SteelBlue;
            btnProfesionales.FlatStyle = FlatStyle.Flat;
            btnProfesionales.ForeColor = Color.White;
            btnProfesionales.Location = new Point(195, 85);
            btnProfesionales.Name = "btnProfesionales";
            btnProfesionales.Size = new Size(160, 40);
            btnProfesionales.TabIndex = 2;
            btnProfesionales.Text = "Profesionales";
            btnProfesionales.UseVisualStyleBackColor = false;
            btnProfesionales.Click += btnProfesionales_Click;
            // 
            // btnTurnosFecha
            // 
            btnTurnosFecha.BackColor = Color.SteelBlue;
            btnTurnosFecha.FlatStyle = FlatStyle.Flat;
            btnTurnosFecha.ForeColor = Color.White;
            btnTurnosFecha.Location = new Point(365, 85);
            btnTurnosFecha.Name = "btnTurnosFecha";
            btnTurnosFecha.Size = new Size(180, 40);
            btnTurnosFecha.TabIndex = 3;
            btnTurnosFecha.Text = "Turnos por fecha";
            btnTurnosFecha.UseVisualStyleBackColor = false;
            btnTurnosFecha.Click += btnTurnosFecha_Click;
            // 
            // btnPendientes
            // 
            btnPendientes.BackColor = Color.SteelBlue;
            btnPendientes.FlatStyle = FlatStyle.Flat;
            btnPendientes.ForeColor = Color.White;
            btnPendientes.Location = new Point(557, 85);
            btnPendientes.Name = "btnPendientes";
            btnPendientes.Size = new Size(194, 40);
            btnPendientes.TabIndex = 4;
            btnPendientes.Text = "Turnos pendientes";
            btnPendientes.UseVisualStyleBackColor = false;
            btnPendientes.Click += btnPendientes_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.SteelBlue;
            btnHistorial.FlatStyle = FlatStyle.Flat;
            btnHistorial.ForeColor = Color.White;
            btnHistorial.Location = new Point(25, 140);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(224, 40);
            btnHistorial.TabIndex = 5;
            btnHistorial.Text = "Historial por paciente";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // dtpFechaReporte
            // 
            dtpFechaReporte.Format = DateTimePickerFormat.Short;
            dtpFechaReporte.Location = new Point(327, 145);
            dtpFechaReporte.Name = "dtpFechaReporte";
            dtpFechaReporte.Size = new Size(160, 35);
            dtpFechaReporte.TabIndex = 6;
            // 
            // lblFechaReporte
            // 
            lblFechaReporte.AutoSize = true;
            lblFechaReporte.Location = new Point(251, 145);
            lblFechaReporte.Name = "lblFechaReporte";
            lblFechaReporte.Size = new Size(72, 30);
            lblFechaReporte.TabIndex = 7;
            lblFechaReporte.Text = "Fecha:";
            // 
            // cboPacienteReporte
            // 
            cboPacienteReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPacienteReporte.FormattingEnabled = true;
            cboPacienteReporte.Location = new Point(599, 146);
            cboPacienteReporte.Name = "cboPacienteReporte";
            cboPacienteReporte.Size = new Size(210, 38);
            cboPacienteReporte.TabIndex = 8;
            // 
            // lblPacienteReporte
            // 
            lblPacienteReporte.AutoSize = true;
            lblPacienteReporte.Location = new Point(497, 149);
            lblPacienteReporte.Name = "lblPacienteReporte";
            lblPacienteReporte.Size = new Size(96, 30);
            lblPacienteReporte.TabIndex = 9;
            lblPacienteReporte.Text = "Paciente:";
            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(25, 210);
            dgvReportes.MultiSelect = false;
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.RowHeadersVisible = false;
            dgvReportes.RowHeadersWidth = 72;
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.Size = new Size(850, 330);
            dgvReportes.TabIndex = 10;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(906, 556);
            Controls.Add(dgvReportes);
            Controls.Add(lblPacienteReporte);
            Controls.Add(cboPacienteReporte);
            Controls.Add(lblFechaReporte);
            Controls.Add(dtpFechaReporte);
            Controls.Add(btnHistorial);
            Controls.Add(btnPendientes);
            Controls.Add(btnTurnosFecha);
            Controls.Add(btnProfesionales);
            Controls.Add(btnPacientes);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Turnos - Reportes";
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnPacientes;
        private Button btnProfesionales;
        private Button btnTurnosFecha;
        private Button btnPendientes;
        private Button btnHistorial;
        private DateTimePicker dtpFechaReporte;
        private Label lblFechaReporte;
        private ComboBox cboPacienteReporte;
        private Label lblPacienteReporte;
        private DataGridView dgvReportes;
    }
}