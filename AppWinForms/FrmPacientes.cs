using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace AppWinForms
{
    public partial class FrmPacientes : Form
    {

        private readonly Repositorio<Paciente> _repo = new();

        // null = alta de un paciente nuevo; con valor = modificando ese Id
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
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarGrilla();
            LimpiarFormulario();
        }

        // ---------- CONSULTA ----------
        private void CargarGrilla()
        {
            var pacientes = _repo.ObtenerTodos();

            var filtro = txtBuscar.Text.Trim();
            if (filtro.Length > 0)
            {
                pacientes = pacientes.Where(p =>
                    p.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    p.Apellido.Contains(filtro, StringComparison.OrdinalIgnoreCase) ||
                    p.DNI.Contains(filtro)).ToList();
            }

            dgvPacientes.DataSource = pacientes.OrderBy(p => p.Apellido).ToList();

            // Ocultar columnas técnicas y mejorar encabezados
            foreach (var nombre in new[] { "Id", "Turnos" })
                if (dgvPacientes.Columns[nombre] is { } col) col.Visible = false;

            if (dgvPacientes.Columns["FechaNacimiento"] is { } fn)
            {
                fn.HeaderText = "Fecha de nacimiento";
                fn.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvPacientes.Columns["Telefono"] is { } tel) tel.HeaderText = "Teléfono";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void dgvPacientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0) return;
            if (dgvPacientes.SelectedRows[0].DataBoundItem is not Paciente p) return;

            _idSeleccionado = p.Id;
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;
            txtDni.Text = p.DNI;
            txtTelefono.Text = p.Telefono;
            txtEmail.Text = p.Email;

            var fecha = p.FechaNacimiento;
            if (fecha < dtpFechaNacimiento.MinDate) fecha = dtpFechaNacimiento.MinDate;
            if (fecha > dtpFechaNacimiento.MaxDate) fecha = dtpFechaNacimiento.MaxDate;
            dtpFechaNacimiento.Value = fecha;
        }

        // ---------- ALTA (preparar formulario vacío) ----------
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

        // ---------- ALTA y MODIFICACIÓN ----------
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Nombre, apellido y DNI son obligatorios.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var paciente = new Paciente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                DNI = txtDni.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date
            };

            try
            {
                if (_idSeleccionado is null)
                {
                    _repo.Agregar(paciente);
                    MessageBox.Show("Paciente agregado.", "OK");
                }
                else
                {
                    paciente.Id = _idSeleccionado.Value;
                    _repo.Modificar(paciente);
                    MessageBox.Show("Paciente modificado.", "OK");
                }

                CargarGrilla();
                LimpiarFormulario();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("No se pudo guardar. Verificá que el DNI no esté repetido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- BAJA ----------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado is null)
            {
                MessageBox.Show("Seleccioná un paciente de la grilla.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show("¿Eliminar el paciente seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) return;

            try
            {
                _repo.Eliminar(_idSeleccionado.Value);
                CargarGrilla();
                LimpiarFormulario();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("No se puede eliminar: el paciente tiene turnos asociados.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
