
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppWinForms
{
    partial class FrmTurnos
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblPaciente;
        private Label lblProfesional;
        private Label lblFecha;
        private Label lblHora;
        private Label lblEstado;
        private Label lblTurnos;

        private ComboBox cboPaciente;
        private ComboBox cboProfesional;
        private DateTimePicker dtpFecha;
        private DateTimePicker dtpHora;
        private ComboBox cboEstado;

        private Button btnGuardar;
        private Button btnActualizar;
        private DataGridView dgvTurnos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblPaciente = new Label();
            lblProfesional = new Label();
            lblFecha = new Label();
            lblHora = new Label();
            lblEstado = new Label();
            lblTurnos = new Label();

            cboPaciente = new ComboBox();
            cboProfesional = new ComboBox();
            dtpFecha = new DateTimePicker();
            dtpHora = new DateTimePicker();
            cboEstado = new ComboBox();

            btnGuardar = new Button();
            btnActualizar = new Button();
            dgvTurnos = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvTurnos)
                .BeginInit();

            SuspendLayout();

            // =====================================
            // TÍTULO
            // =====================================

            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Gestión De Turnos";
            lblTitulo.Location = new Point(20, 35);
            lblTitulo.Size = new Size(450, 38);
            lblTitulo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MidnightBlue;

            // =====================================
            // PACIENTE
            // =====================================

            lblPaciente.Name = "lblPaciente";
            lblPaciente.Text = "Paciente:";
            lblPaciente.Location = new Point(15, 88);
            lblPaciente.Size = new Size(65, 22);

            cboPaciente.Name = "cboPaciente";
            cboPaciente.Location = new Point(82, 85);
            cboPaciente.Size = new Size(155, 23);
            cboPaciente.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // =====================================
            // PROFESIONAL
            // =====================================

            lblProfesional.Name = "lblProfesional";
            lblProfesional.Text = "Profesional:";
            lblProfesional.Location = new Point(250, 88);
            lblProfesional.Size = new Size(85, 22);

            cboProfesional.Name = "cboProfesional";
            cboProfesional.Location = new Point(335, 85);
            cboProfesional.Size = new Size(160, 23);
            cboProfesional.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // =====================================
            // FECHA
            // =====================================

            lblFecha.Name = "lblFecha";
            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(15, 120);
            lblFecha.Size = new Size(45, 22);

            dtpFecha.Name = "dtpFecha";
            dtpFecha.Location = new Point(60, 117);
            dtpFecha.Size = new Size(100, 23);
            dtpFecha.Format = DateTimePickerFormat.Short;

            // =====================================
            // HORA
            // =====================================

            lblHora.Name = "lblHora";
            lblHora.Text = "Hora:";
            lblHora.Location = new Point(170, 120);
            lblHora.Size = new Size(40, 22);

            dtpHora.Name = "dtpHora";
            dtpHora.Location = new Point(210, 117);
            dtpHora.Size = new Size(80, 23);
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.ShowUpDown = true;

            // =====================================
            // ESTADO
            // =====================================

            lblEstado.Name = "lblEstado";
            lblEstado.Text = "Estado:";
            lblEstado.Location = new Point(300, 120);
            lblEstado.Size = new Size(55, 22);

            cboEstado.Name = "cboEstado";
            cboEstado.Location = new Point(355, 117);
            cboEstado.Size = new Size(140, 23);
            cboEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboEstado.Items.AddRange(new object[]
            {
                "Pendiente",
                "Confirmado",
                "Cancelado",
                "Atendido"
            });

            // =====================================
            // BOTÓN GUARDAR
            // =====================================

            btnGuardar.Name = "btnGuardar";
            btnGuardar.Text = "Guardar turno";
            btnGuardar.Location = new Point(15, 150);
            btnGuardar.Size = new Size(120, 25);
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // =====================================
            // BOTÓN ACTUALIZAR
            // =====================================

            btnActualizar.Name = "btnActualizar";
            btnActualizar.Text = "Actualizar lista";
            btnActualizar.Location = new Point(145, 150);
            btnActualizar.Size = new Size(120, 25);
            btnActualizar.BackColor = Color.SteelBlue;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;

            // =====================================
            // TÍTULO DE TABLA
            // =====================================

            lblTurnos.Name = "lblTurnos";
            lblTurnos.Text = "Turnos registrados";
            lblTurnos.Location = new Point(15, 182);
            lblTurnos.Size = new Size(250, 22);
            lblTurnos.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblTurnos.ForeColor = Color.MidnightBlue;

            // =====================================
            // TABLA
            // =====================================

            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.Location = new Point(15, 208);
            dgvTurnos.Size = new Size(480, 117);
            dgvTurnos.BackgroundColor =
                Color.FromArgb(160, 160, 160);
            dgvTurnos.BorderStyle =
                BorderStyle.FixedSingle;
            dgvTurnos.ReadOnly = true;
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.MultiSelect = false;
            dgvTurnos.RowHeadersVisible = false;
            dgvTurnos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvTurnos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // =====================================
            // FORMULARIO
            // =====================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 340);

            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            Name = "FrmTurnos";
            Text = "Sistema de Gestión de Turnos - Turnos";

            Controls.Add(lblTitulo);
            Controls.Add(lblPaciente);
            Controls.Add(cboPaciente);
            Controls.Add(lblProfesional);
            Controls.Add(cboProfesional);
            Controls.Add(lblFecha);
            Controls.Add(dtpFecha);
            Controls.Add(lblHora);
            Controls.Add(dtpHora);
            Controls.Add(lblEstado);
            Controls.Add(cboEstado);
            Controls.Add(btnGuardar);
            Controls.Add(btnActualizar);
            Controls.Add(lblTurnos);
            Controls.Add(dgvTurnos);

            ((System.ComponentModel.ISupportInitialize)dgvTurnos)
                .EndInit();

            ResumeLayout(false);
        }
    }
}
