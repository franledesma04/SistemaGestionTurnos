using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace AppWinForms
{
    public partial class FrmPacientes : Form
    {
        private readonly Repositorio<Paciente> _repo = new();

        // null = paciente nuevo; con valor = modificación
        private int? _idSeleccionado = null;

        public FrmPacientes()
        {
            InitializeComponent();
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {
            dtpFechaNacimiento.MaxDate = DateTime.Today;

            dgvPacientes.ReadOnly = true;
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.AllowUserToDeleteRows = false;
            dgvPacientes.MultiSelect = false;
            dgvPacientes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            CargarGrilla();
            LimpiarFormulario();
        }

        // CONSULTAR PACIENTES
        private void CargarGrilla()
        {
            var pacientes = _repo.ObtenerTodos();

            var filtro = txtBuscar.Text.Trim();

            if (filtro.Length > 0)
            {
                pacientes = pacientes.Where(p =>
                    p.Nombre.Contains(
                        filtro,
                        StringComparison.OrdinalIgnoreCase) ||
                    p.Apellido.Contains(
                        filtro,
                        StringComparison.OrdinalIgnoreCase) ||
                    p.DNI.Contains(filtro)).ToList();
            }

            dgvPacientes.DataSource =
                pacientes.OrderBy(p => p.Apellido).ToList();

            foreach (var nombre in new[] { "Id", "Turnos" })
            {
                if (dgvPacientes.Columns[nombre] is { } col)
                    col.Visible = false;
            }

            if (dgvPacientes.Columns["FechaNacimiento"] is { } fn)
            {
                fn.HeaderText = "Fecha de nacimiento";
                fn.DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvPacientes.Columns["Telefono"] is { } tel)
                tel.HeaderText = "Teléfono";
        }

        // BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        // SELECCIONAR PACIENTE
        private void dgvPacientes_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
                return;

            if (dgvPacientes.SelectedRows[0].DataBoundItem
                is not Paciente p)
                return;

            _idSeleccionado = p.Id;

            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            txtDni.Text = p.DNI;
            txtTelefono.Text = p.Telefono;
            txtEmail.Text = p.Email;

            var fecha = p.FechaNacimiento;

            if (fecha < dtpFechaNacimiento.MinDate)
                fecha = dtpFechaNacimiento.MinDate;

            if (fecha > dtpFechaNacimiento.MaxDate)
                fecha = dtpFechaNacimiento.MaxDate;

            dtpFechaNacimiento.Value = fecha;
        }

        // NUEVO PACIENTE
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            dgvPacientes.ClearSelection();

            _idSeleccionado = null;

            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

            dtpFechaNacimiento.Value = DateTime.Today;

            txtNombre.Focus();
        }

        // VALIDACIONES
        private bool ValidarPaciente()
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string dni = txtDni.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Campos obligatorios
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show(
                    "Nombre, apellido y DNI son obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            // Nombre y apellido: letras y espacios
            if (!Regex.IsMatch(nombre, @"^[\p{L}\s]+$") ||
                !Regex.IsMatch(apellido, @"^[\p{L}\s]+$"))
            {
                MessageBox.Show(
                    "El nombre y el apellido solo pueden contener letras.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            // DNI: 7 u 8 dígitos
            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                MessageBox.Show(
                    "El DNI debe contener 7 u 8 números, sin puntos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            // Teléfono opcional, pero numérico
            if (telefono.Length > 0 &&
                !Regex.IsMatch(telefono, @"^\d+$"))
            {
                MessageBox.Show(
                    "El teléfono debe contener solamente números.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            // Correo electrónico opcional
            if (email.Length > 0 &&
                !Regex.IsMatch(
                    email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(
                    "Ingresá un correo electrónico válido.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            // Fecha de nacimiento
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no puede ser futura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        // GUARDAR O MODIFICAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarPaciente())
                return;

            var paciente = new Paciente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                DNI = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaNacimiento =
                    dtpFechaNacimiento.Value.Date
            };

            try
            {
                if (_idSeleccionado is null)
                {
                    _repo.Agregar(paciente);

                    MessageBox.Show(
                        "Paciente agregado correctamente.",
                        "OK"
                    );
                }
                else
                {
                    paciente.Id = _idSeleccionado.Value;

                    _repo.Modificar(paciente);

                    MessageBox.Show(
                        "Paciente modificado correctamente.",
                        "OK"
                    );
                }

                CargarGrilla();
                LimpiarFormulario();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se pudo guardar. Verificá que el DNI no esté repetido.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ELIMINAR PACIENTE
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado is null)
            {
                MessageBox.Show(
                    "Seleccioná un paciente de la grilla.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var respuesta = MessageBox.Show(
                "¿Eliminar el paciente seleccionado?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _repo.Eliminar(_idSeleccionado.Value);

                CargarGrilla();
                LimpiarFormulario();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se puede eliminar: el paciente tiene turnos asociados.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}