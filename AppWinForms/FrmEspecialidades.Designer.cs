
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppWinForms
{
    partial class FrmEspecialidades
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNombre;
        private Label lblDescripcion;
        private Label lblListado;

        private TextBox txtNombre;
        private TextBox txtDescripcion;

        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnActualizar;

        private DataGridView dgvEspecialidades;

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
            lblDescripcion = new Label();
            lblListado = new Label();

            txtNombre = new TextBox();
            txtDescripcion = new TextBox();

            btnGuardar = new Button();
            btnNuevo = new Button();
            btnActualizar = new Button();

            dgvEspecialidades = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades)
                .BeginInit();

            SuspendLayout();

            // =====================================
            // TÍTULO
            // =====================================

            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Gestión De Especialidades";
            lblTitulo.Location = new Point(20, 30);
            lblTitulo.Size = new Size(470, 40);
            lblTitulo.Font = new Font(
                "Segoe UI", 17F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MidnightBlue;

            // =====================================
            // NOMBRE
            // =====================================

            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(15, 90);
            lblNombre.Size = new Size(75, 23);

            txtNombre.Name = "txtNombre";
            txtNombre.Location = new Point(95, 87);
            txtNombre.Size = new Size(400, 23);

            // =====================================
            // DESCRIPCIÓN
            // =====================================

            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Text = "Descripción:";
            lblDescripcion.Location = new Point(15, 125);
            lblDescripcion.Size = new Size(80, 23);

            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Location = new Point(95, 122);
            txtDescripcion.Size = new Size(400, 23);

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
            lblListado.Text = "Especialidades registradas";
            lblListado.Location = new Point(15, 200);
            lblListado.Size = new Size(300, 23);
            lblListado.Font = new Font(
                "Segoe UI", 9F, FontStyle.Bold);
            lblListado.ForeColor = Color.MidnightBlue;

            // =====================================
            // TABLA
            // =====================================

            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.Location = new Point(15, 230);
            dgvEspecialidades.Size = new Size(480, 95);
            dgvEspecialidades.BackgroundColor =
                Color.FromArgb(160, 160, 160);
            dgvEspecialidades.BorderStyle =
                BorderStyle.FixedSingle;
            dgvEspecialidades.ReadOnly = true;
            dgvEspecialidades.AllowUserToAddRows = false;
            dgvEspecialidades.AllowUserToDeleteRows = false;
            dgvEspecialidades.MultiSelect = false;
            dgvEspecialidades.RowHeadersVisible = false;
            dgvEspecialidades.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvEspecialidades.AutoSizeColumnsMode =
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

            Name = "FrmEspecialidades";
            Text = "Sistema de Gestión de Turnos - Especialidades";

            Controls.Add(lblTitulo);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(btnActualizar);
            Controls.Add(lblListado);
            Controls.Add(dgvEspecialidades);

            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades)
                .EndInit();

            ResumeLayout(false);
        }
    }
}
