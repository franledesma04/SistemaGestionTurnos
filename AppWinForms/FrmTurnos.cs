
using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;
using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppWinForms
{
    public partial class FrmTurnos : Form
    {
        private readonly ApplicationDbContext _context;

        // Constructor para el diseñador.
        public FrmTurnos()
        {
            InitializeComponent();
            _context = null!;
        }

        // Constructor utilizado por la aplicación.
        public FrmTurnos(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;

            CargarPacientes();
            CargarProfesionales();
            CargarTurnos();

            if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;
        }

        // =====================================
        // CARGAR PACIENTES
        // =====================================

        private void CargarPacientes()
        {
            try
            {
                var pacientes = _context.Pacientes
                    .AsNoTracking()
                    .OrderBy(p => p.Apellido)
                    .ThenBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Id,
                        NombreCompleto =
                            p.Apellido + ", " + p.Nombre
                    })
                    .ToList();

                cboPaciente.DataSource = pacientes;
                cboPaciente.DisplayMember = "NombreCompleto";
                cboPaciente.ValueMember = "Id";
                cboPaciente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("cargar pacientes", ex);
            }
        }

        // =====================================
        // CARGAR PROFESIONALES
        // =====================================

        private void CargarProfesionales()
        {
            try
            {
                var profesionales = _context.Profesionales
                    .AsNoTracking()
                    .OrderBy(p => p.Apellido)
                    .ThenBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Id,
                        NombreCompleto =
                            p.Apellido + ", " + p.Nombre
                    })
                    .ToList();

                cboProfesional.DataSource = profesionales;
                cboProfesional.DisplayMember = "NombreCompleto";
                cboProfesional.ValueMember = "Id";
                cboProfesional.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("cargar profesionales", ex);
            }
        }

        // =====================================
        // CARGAR TURNOS EN LA TABLA
        // =====================================

        private void CargarTurnos()
        {
            try
            {
                var turnos = _context.Turnos
                    .AsNoTracking()
                    .Select(t => new
                    {
                        t.Id,
                        t.Fecha,
                        t.Hora,

                        Paciente =
                            t.Paciente.Nombre + " " +
                            t.Paciente.Apellido,

                        Profesional =
                            t.Profesional.Nombre + " " +
                            t.Profesional.Apellido,

                        t.Estado
                    })
                    .ToList()
                    .OrderBy(t => t.Fecha)
                    .ThenBy(t => t.Hora)
                    .ToList();

                dgvTurnos.DataSource = turnos;

                dgvTurnos.ReadOnly = true;
                dgvTurnos.AllowUserToAddRows = false;
                dgvTurnos.AllowUserToDeleteRows = false;
                dgvTurnos.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvTurnos.MultiSelect = false;
                dgvTurnos.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvTurnos.Columns["Fecha"] != null)
                    dgvTurnos.Columns["Fecha"].DefaultCellStyle.Format =
                        "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MostrarError("cargar turnos", ex);
            }
        }

        // =====================================
        // GUARDAR TURNO
        // =====================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar paciente.
            if (cboPaciente.SelectedIndex < 0 ||
                cboPaciente.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccioná un paciente.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validar profesional.
            if (cboProfesional.SelectedIndex < 0 ||
                cboProfesional.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccioná un profesional.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validar estado.
            if (cboEstado.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Seleccioná el estado del turno.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;

            // No permitir fechas anteriores.
            if (fecha < DateTime.Today)
            {
                MessageBox.Show(
                    "No podés registrar turnos en fechas anteriores.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                int pacienteId = Convert.ToInt32(
                    cboPaciente.SelectedValue);

                int profesionalId = Convert.ToInt32(
                    cboProfesional.SelectedValue);

                string estado = cboEstado.SelectedItem!.ToString()!;

                // Verificar que el paciente exista.
                bool pacienteExiste = _context.Pacientes
                    .AsNoTracking()
                    .Any(p => p.Id == pacienteId);

                if (!pacienteExiste)
                {
                    MessageBox.Show(
                        "El paciente seleccionado ya no existe.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CargarPacientes();
                    return;
                }

                // Verificar que el profesional exista.
                bool profesionalExiste = _context.Profesionales
                    .AsNoTracking()
                    .Any(p => p.Id == profesionalId);

                if (!profesionalExiste)
                {
                    MessageBox.Show(
                        "El profesional seleccionado ya no existe.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CargarProfesionales();
                    return;
                }

                // Verificar si el profesional ya tiene
                // un turno en la misma fecha y horario.
                bool horarioOcupado = _context.Turnos
                    .AsNoTracking()
                    .Any(t =>
                        t.ProfesionalId == profesionalId &&
                        t.Fecha == fecha &&
                        t.Hora == hora);

                if (horarioOcupado)
                {
                    MessageBox.Show(
                        "El profesional ya tiene un turno registrado en ese horario.",
                        "Horario ocupado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Crear el turno usando solamente las claves foráneas.
                var turno = new Turno
                {
                    PacienteId = pacienteId,
                    ProfesionalId = profesionalId,
                    Fecha = fecha,
                    Hora = hora,
                    Estado = estado
                };

                _context.Turnos.Add(turno);

                _context.SaveChanges();

                MessageBox.Show(
                    "Turno registrado correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarTurnos();

                LimpiarCampos();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se pudo registrar el turno. Verificá que el horario del profesional no esté ocupado.",
                    "Error al guardar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MostrarError("guardar el turno", ex);
            }
        }

        // =====================================
        // ACTUALIZAR LISTA
        // =====================================

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarPacientes();
            CargarProfesionales();
            CargarTurnos();
        }

        // =====================================
        // LIMPIAR CAMPOS
        // =====================================

        private void LimpiarCampos()
        {
            cboPaciente.SelectedIndex = -1;
            cboProfesional.SelectedIndex = -1;

            if (cboEstado.Items.Count > 0)
                cboEstado.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Today;

            dgvTurnos.ClearSelection();
        }

        // =====================================
        // MOSTRAR ERRORES
        // =====================================

        private void MostrarError(string operacion, Exception ex)
        {
            MessageBox.Show(
                "Error al " + operacion + ": " + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
