
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppWinForms
{
    partial class FrmPacientes
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private Label lblTelefono;
        private Label lblEmail;
        private Label lblFechaNacimiento;
        private Label lblBuscar;
        private Label lblListado;

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtBuscar;

        private DateTimePicker dtpFechaNacimiento;

        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnBuscar;

        private DataGridView dgvPacientes;

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
            lblDni = new Label();
            lblTelefono = new Label();
            lblEmail = new Label();
            lblFechaNacimiento = new Label();
            lblBuscar = new Label();
            lblListado = new Label();

            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtBuscar = new TextBox();

            dtpFechaNacimiento = new DateTimePicker();

            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnBuscar = new Button();

            dgvPacientes = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvPacientes)
                .BeginInit();

            SuspendLayout();

            // =====================================
            // TÍTULO PRINCIPAL
            // =====================================

            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Gestión De Pacientes";
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(470, 38);
            lblTitulo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MidnightBlue;

            // =====================================
            // NOMBRE
            // =====================================

            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(15, 68);
            lblNombre.Size = new Size(65, 22);

            txtNombre.Name = "txtNombre";
            txtNombre.Location = new Point(85, 65);
            txtNombre.Size = new Size(150, 23);

            // =====================================
            // APELLIDO
            // =====================================

            lblApellido.Name = "lblApellido";
            lblApellido.Text = "Apellido:";
            lblApellido.Location = new Point(250, 68);
            lblApellido.Size = new Size(65, 22);

            txtApellido.Name = "txtApellido";
            txtApellido.Location = new Point(325, 65);
            txtApellido.Size = new Size(170, 23);

            // =====================================
            // DNI
            // =====================================

            lblDni.Name = "lblDni";
            lblDni.Text = "DNI:";
            lblDni.Location = new Point(15, 103);
            lblDni.Size = new Size(65, 22);

            txtDni.Name = "txtDni";
            txtDni.Location = new Point(85, 100);
            txtDni.Size = new Size(150, 23);

            // =====================================
            // TELÉFONO
            // =====================================

            lblTelefono.Name = "lblTelefono";
            lblTelefono.Text = "Teléfono:";
            lblTelefono.Location = new Point(250, 103);
            lblTelefono.Size = new Size(75, 22);

            txtTelefono.Name = "txtTelefono";
            txtTelefono.Location = new Point(325, 100);
            txtTelefono.Size = new Size(170, 23);

            // =====================================
            // EMAIL
            // =====================================

            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(15, 138);
            lblEmail.Size = new Size(65, 22);

            txtEmail.Name = "txtEmail";
            txtEmail.Location = new Point(85, 135);
            txtEmail.Size = new Size(150, 23);

            // =====================================
            // FECHA DE NACIMIENTO
            // =====================================

            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Text = "Fecha nac.:";
            lblFechaNacimiento.Location = new Point(250, 138);
            lblFechaNacimiento.Size = new Size(75, 22);

            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Location = new Point(325, 135);
            dtpFechaNacimiento.Size = new Size(170, 23);
            dtpFechaNacimiento.Format =
                DateTimePickerFormat.Short;

            // =====================================
            // BOTÓN NUEVO
            // =====================================

            btnNuevo.Name = "btnNuevo";
            btnNuevo.Text = "Nuevo";
            btnNuevo.Location = new Point(15, 175);
            btnNuevo.Size = new Size(110, 27);
            btnNuevo.BackColor = Color.SteelBlue;
            btnNuevo.ForeColor = Color.White;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;

            // =====================================
            // BOTÓN GUARDAR
            // =====================================

            btnGuardar.Name = "btnGuardar";
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(135, 175);
            btnGuardar.Size = new Size(110, 27);
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // =====================================
            // BOTÓN ELIMINAR
            // =====================================

            btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(255, 175);
            btnEliminar.Size = new Size(110, 27);
            btnEliminar.BackColor = Color.SteelBlue;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            // =====================================
            // BUSCAR PACIENTE
            // =====================================

            lblBuscar.Name = "lblBuscar";
            lblBuscar.Text = "Buscar:";
            lblBuscar.Location = new Point(15, 219);
            lblBuscar.Size = new Size(65, 22);

            txtBuscar.Name = "txtBuscar";
            txtBuscar.Location = new Point(85, 216);
            txtBuscar.Size = new Size(280, 23);
            txtBuscar.PlaceholderText =
                "Nombre, apellido o DNI";

            btnBuscar.Name = "btnBuscar";
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(375, 214);
            btnBuscar.Size = new Size(120, 27);
            btnBuscar.BackColor = Color.SteelBlue;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;

            // =====================================
            // TÍTULO DE LA TABLA
            // =====================================

            lblListado.Name = "lblListado";
            lblListado.Text = "Pacientes registrados";
            lblListado.Location = new Point(15, 253);
            lblListado.Size = new Size(300, 23);
            lblListado.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblListado.ForeColor = Color.MidnightBlue;

            // =====================================
            // TABLA DE PACIENTES
            // =====================================

            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.Location = new Point(15, 280);
            dgvPacientes.Size = new Size(480, 95);
            dgvPacientes.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;

            dgvPacientes.BackgroundColor =
                Color.FromArgb(160, 160, 160);

            dgvPacientes.BorderStyle =
                BorderStyle.FixedSingle;

            dgvPacientes.ReadOnly = true;
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.MultiSelect = false;
            dgvPacientes.RowHeadersVisible = false;

            dgvPacientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPacientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPacientes.SelectionChanged +=
                dgvPacientes_SelectionChanged;

            // =====================================
            // FORMULARIO
            // =====================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(510, 390);

            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9F);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            Name = "FrmPacientes";
            Text = "Sistema de Gestión de Turnos - Pacientes";

            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(lblListado);
            Controls.Add(dgvPacientes);

            Load += FrmPacientes_Load;

            ((System.ComponentModel.ISupportInitialize)dgvPacientes)
                .EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}

