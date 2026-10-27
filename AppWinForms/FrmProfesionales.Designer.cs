
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppWinForms
{
    partial class FrmProfesionales
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblMatricula;
        private Label lblEspecialidad;
        private Label lblListado;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtMatricula;

        private ComboBox cboEspecialidad;

        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnActualizar;

        private DataGridView dgvProfesionales;

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
            lblNombre = new Label();
            lblApellido = new Label();
            lblMatricula = new Label();
            lblEspecialidad = new Label();
            lblListado = new Label();

            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtMatricula = new TextBox();

            cboEspecialidad = new ComboBox();

            btnGuardar = new Button();
            btnNuevo = new Button();
            btnActualizar = new Button();

            dgvProfesionales = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvProfesionales)
                .BeginInit();

            SuspendLayout();

            // =====================================
            // TÍTULO
            // =====================================

            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Gestión De Profesionales";
            lblTitulo.Location = new Point(20, 30);
            lblTitulo.Size = new Size(460, 40);
            lblTitulo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MidnightBlue;

            // =====================================
            // NOMBRE
            // =====================================

            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(15, 88);
            lblNombre.Size = new Size(65, 22);

            txtNombre.Name = "txtNombre";
            txtNombre.Location = new Point(85, 85);
            txtNombre.Size = new Size(155, 23);

            // =====================================
            // APELLIDO
            // =====================================

            lblApellido.Name = "lblApellido";
            lblApellido.Text = "Apellido:";
            lblApellido.Location = new Point(255, 88);
            lblApellido.Size = new Size(65, 22);

            txtApellido.Name = "txtApellido";
            txtApellido.Location = new Point(325, 85);
            txtApellido.Size = new Size(170, 23);

            // =====================================
            // MATRÍCULA
            // =====================================

            lblMatricula.Name = "lblMatricula";
            lblMatricula.Text = "Matrícula:";
            lblMatricula.Location = new Point(15, 123);
            lblMatricula.Size = new Size(70, 22);

            txtMatricula.Name = "txtMatricula";
            txtMatricula.Location = new Point(85, 120);
            txtMatricula.Size = new Size(155, 23);

            // =====================================
            // ESPECIALIDAD
            // =====================================

            lblEspecialidad.Name = "lblEspecialidad";
            lblEspecialidad.Text = "Especialidad:";
            lblEspecialidad.Location = new Point(255, 123);
            lblEspecialidad.Size = new Size(90, 22);

            cboEspecialidad.Name = "cboEspecialidad";
            cboEspecialidad.Location = new Point(345, 120);
            cboEspecialidad.Size = new Size(150, 23);
            cboEspecialidad.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // =====================================
            // BOTÓN GUARDAR
            // =====================================

            btnGuardar.Name = "btnGuardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(15, 160);
            btnGuardar.Size = new Size(110, 27);
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // =====================================
            // BOTÓN NUEVO
            // =====================================

            btnNuevo.Name = "btnNuevo";
            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new Point(135, 160);
            btnNuevo.Size = new Size(110, 27);
            btnNuevo.BackColor = Color.SteelBlue;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;

            // =====================================
            // BOTÓN ACTUALIZAR
            // =====================================

            btnActualizar.Name = "btnActualizar";
            btnActualizar.Text = "Actualizar lista";
            btnActualizar.Location = new Point(255, 160);
            btnActualizar.Size = new Size(130, 27);
            btnActualizar.BackColor = Color.SteelBlue;
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;

            // =====================================
            // TÍTULO DE LA TABLA
            // =====================================

            lblListado.Name = "lblListado";
            lblListado.Text = "Profesionales registrados";
            lblListado.Location = new Point(15, 200);
            lblListado.Size = new Size(300, 23);
            lblListado.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblListado.ForeColor = Color.MidnightBlue;

            // =====================================
            // TABLA
            // =====================================

            dgvProfesionales.Name = "dgvProfesionales";
            dgvProfesionales.Location = new Point(15, 230);
            dgvProfesionales.Size = new Size(480, 95);
            dgvProfesionales.BackgroundColor =
                Color.FromArgb(160, 160, 160);
            dgvProfesionales.BorderStyle =
                BorderStyle.FixedSingle;
            dgvProfesionales.ReadOnly = true;
            dgvProfesionales.AllowUserToAddRows = false;
            dgvProfesionales.AllowUserToDeleteRows = false;
            dgvProfesionales.MultiSelect = false;
            dgvProfesionales.RowHeadersVisible = false;
            dgvProfesionales.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvProfesionales.AutoSizeColumnsMode =
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

            Name = "FrmProfesionales";
            Text = "Sistema de Gestión de Turnos - Profesionales";

            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblMatricula);
            Controls.Add(txtMatricula);
            Controls.Add(lblEspecialidad);
            Controls.Add(cboEspecialidad);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(btnActualizar);
            Controls.Add(lblListado);
            Controls.Add(dgvProfesionales);

            ((System.ComponentModel.ISupportInitialize)dgvProfesionales)
                .EndInit();

            ResumeLayout(false);
        }
    }
}
