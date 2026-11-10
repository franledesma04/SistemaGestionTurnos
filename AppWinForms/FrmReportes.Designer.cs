
namespace AppWinForms
{
    partial class FrmReportes
    {
        private System.ComponentModel.IContainer components = null;

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

        private Label lblProfesionalReporte;
        private ComboBox cboProfesionalReporte;
        private Label lblDesdeReporte;
        private DateTimePicker dtpDesdeReporte;
        private Label lblHastaReporte;
        private DateTimePicker dtpHastaReporte;
        private Button btnTurnosProfesional;

        private Label lblEspecialidadReporte;
        private ComboBox cboEspecialidadReporte;
        private Button btnTurnosEspecialidad;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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

            lblProfesionalReporte = new Label();
            cboProfesionalReporte = new ComboBox();
            lblDesdeReporte = new Label();
            dtpDesdeReporte = new DateTimePicker();
            lblHastaReporte = new Label();
            dtpHastaReporte = new DateTimePicker();
            btnTurnosProfesional = new Button();

            lblEspecialidadReporte = new Label();
            cboEspecialidadReporte = new ComboBox();
            btnTurnosEspecialidad = new Button();

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
            lblTitulo.Size = new Size(400, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Reportes De Consultorio";

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
            btnPacientes.Click += Button1_Click;

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
            btnProfesionales.Click += BtnProfesionales_Click;

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
            btnTurnosFecha.Click += BtnTurnosFecha_Click;

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
            btnPendientes.Click += BtnPendientes_Click;

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
            btnHistorial.Click += BtnHistorial_Click;

            // 
            // dtpFechaReporte
            // 
            dtpFechaReporte.Format = DateTimePickerFormat.Short;
            dtpFechaReporte.Location = new Point(327, 145);
            dtpFechaReporte.Name = "dtpFechaReporte";
            dtpFechaReporte.Size = new Size(160, 30);
            dtpFechaReporte.TabIndex = 6;

            // 
            // lblFechaReporte
            // 
            lblFechaReporte.AutoSize = true;
            lblFechaReporte.Location = new Point(251, 145);
            lblFechaReporte.Name = "lblFechaReporte";
            lblFechaReporte.Size = new Size(55, 20);
            lblFechaReporte.TabIndex = 7;
            lblFechaReporte.Text = "Fecha:";

            // 
            // cboPacienteReporte
            // 
            cboPacienteReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPacienteReporte.FormattingEnabled = true;
            cboPacienteReporte.Location = new Point(599, 146);
            cboPacienteReporte.Name = "cboPacienteReporte";
            cboPacienteReporte.Size = new Size(210, 28);
            cboPacienteReporte.TabIndex = 8;

            // 
            // lblPacienteReporte
            // 
            lblPacienteReporte.AutoSize = true;
            lblPacienteReporte.Location = new Point(497, 149);
            lblPacienteReporte.Name = "lblPacienteReporte";
            lblPacienteReporte.Size = new Size(70, 20);
            lblPacienteReporte.TabIndex = 9;
            lblPacienteReporte.Text = "Paciente:";

            // 
            // lblProfesionalReporte
            // 
            lblProfesionalReporte.AutoSize = true;
            lblProfesionalReporte.Location = new Point(25, 205);
            lblProfesionalReporte.Name = "lblProfesionalReporte";
            lblProfesionalReporte.Size = new Size(78, 20);
            lblProfesionalReporte.TabIndex = 10;
            lblProfesionalReporte.Text = "Profesional:";

            // 
            // cboProfesionalReporte
            // 
            cboProfesionalReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProfesionalReporte.FormattingEnabled = true;
            cboProfesionalReporte.Location = new Point(120, 200);
            cboProfesionalReporte.Name = "cboProfesionalReporte";
            cboProfesionalReporte.Size = new Size(220, 28);
            cboProfesionalReporte.TabIndex = 11;

            // 
            // lblDesdeReporte
            // 
            lblDesdeReporte.AutoSize = true;
            lblDesdeReporte.Location = new Point(360, 205);
            lblDesdeReporte.Name = "lblDesdeReporte";
            lblDesdeReporte.Size = new Size(48, 20);
            lblDesdeReporte.TabIndex = 12;
            lblDesdeReporte.Text = "Desde:";

            // 
            // dtpDesdeReporte
            // 
            dtpDesdeReporte.Format = DateTimePickerFormat.Short;
            dtpDesdeReporte.Location = new Point(420, 200);
            dtpDesdeReporte.Name = "dtpDesdeReporte";
            dtpDesdeReporte.Size = new Size(130, 27);
            dtpDesdeReporte.TabIndex = 13;

            // 
            // lblHastaReporte
            // 
            lblHastaReporte.AutoSize = true;
            lblHastaReporte.Location = new Point(565, 205);
            lblHastaReporte.Name = "lblHastaReporte";
            lblHastaReporte.Size = new Size(45, 20);
            lblHastaReporte.TabIndex = 14;
            lblHastaReporte.Text = "Hasta:";

            // 
            // dtpHastaReporte
            // 
            dtpHastaReporte.Format = DateTimePickerFormat.Short;
            dtpHastaReporte.Location = new Point(625, 200);
            dtpHastaReporte.Name = "dtpHastaReporte";
            dtpHastaReporte.Size = new Size(130, 27);
            dtpHastaReporte.TabIndex = 15;

            // 
            // btnTurnosProfesional
            // 
            btnTurnosProfesional.BackColor = Color.SteelBlue;
            btnTurnosProfesional.FlatStyle = FlatStyle.Flat;
            btnTurnosProfesional.ForeColor = Color.White;
            btnTurnosProfesional.Location = new Point(780, 195);
            btnTurnosProfesional.Name = "btnTurnosProfesional";
            btnTurnosProfesional.Size = new Size(170, 35);
            btnTurnosProfesional.TabIndex = 16;
            btnTurnosProfesional.Text = "Consultar turnos";
            btnTurnosProfesional.UseVisualStyleBackColor = false;
            btnTurnosProfesional.Click += btnTurnosProfesional_Click;

            // 
            // lblEspecialidadReporte
            // 
            lblEspecialidadReporte.AutoSize = true;
            lblEspecialidadReporte.Location = new Point(25, 260);
            lblEspecialidadReporte.Name = "lblEspecialidadReporte";
            lblEspecialidadReporte.Size = new Size(83, 20);
            lblEspecialidadReporte.TabIndex = 17;
            lblEspecialidadReporte.Text = "Especialidad:";

            // 
            // cboEspecialidadReporte
            // 
            cboEspecialidadReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEspecialidadReporte.FormattingEnabled = true;
            cboEspecialidadReporte.Location = new Point(130, 255);
            cboEspecialidadReporte.Name = "cboEspecialidadReporte";
            cboEspecialidadReporte.Size = new Size(220, 28);
            cboEspecialidadReporte.TabIndex = 18;

            // 
            // btnTurnosEspecialidad
            // 
            btnTurnosEspecialidad.BackColor = Color.SteelBlue;
            btnTurnosEspecialidad.FlatStyle = FlatStyle.Flat;
            btnTurnosEspecialidad.ForeColor = Color.White;
            btnTurnosEspecialidad.Location = new Point(370, 250);
            btnTurnosEspecialidad.Name = "btnTurnosEspecialidad";
            btnTurnosEspecialidad.Size = new Size(200, 35);
            btnTurnosEspecialidad.TabIndex = 19;
            btnTurnosEspecialidad.Text = "Consultar por especialidad";
            btnTurnosEspecialidad.UseVisualStyleBackColor = false;
            btnTurnosEspecialidad.Click += btnTurnosEspecialidad_Click;

            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(25, 310);
            dgvReportes.MultiSelect = false;
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.RowHeadersVisible = false;
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.Size = new Size(950, 340);
            dgvReportes.TabIndex = 20;

            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 680);

            Controls.Add(lblTitulo);
            Controls.Add(btnPacientes);
            Controls.Add(btnProfesionales);
            Controls.Add(btnTurnosFecha);
            Controls.Add(btnPendientes);
            Controls.Add(btnHistorial);

            Controls.Add(dtpFechaReporte);
            Controls.Add(lblFechaReporte);
            Controls.Add(cboPacienteReporte);
            Controls.Add(lblPacienteReporte);

            Controls.Add(lblProfesionalReporte);
            Controls.Add(cboProfesionalReporte);
            Controls.Add(lblDesdeReporte);
            Controls.Add(dtpDesdeReporte);
            Controls.Add(lblHastaReporte);
            Controls.Add(dtpHastaReporte);
            Controls.Add(btnTurnosProfesional);

            Controls.Add(lblEspecialidadReporte);
            Controls.Add(cboEspecialidadReporte);
            Controls.Add(btnTurnosEspecialidad);

            Controls.Add(dgvReportes);

            Font = new Font("Segoe UI", 9F);
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
    }
}
