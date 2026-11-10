
using AccesoDatos.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppWinForms
{
    public partial class FrmReportes : Form
    {
        private readonly ApplicationDbContext _context;

        public FrmReportes(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;

            // Cargar los datos de los ComboBox al abrir el formulario
            CargarPacientes();
            CargarProfesionales();
            CargarEspecialidades();

            // Establecer las fechas iniciales
            dtpFechaReporte.Value = DateTime.Today;
            dtpDesdeReporte.Value = DateTime.Today;
            dtpHastaReporte.Value = DateTime.Today;
        }

        // ==========================================
        // CARGAR PACIENTES EN EL COMBOBOX
        // ==========================================
        private void CargarPacientes()
        {
            try
            {
                var pacientes = _context.Pacientes
                    .OrderBy(p => p.Apellido)
                    .ThenBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Id,
                        NombreCompleto = p.Apellido + ", " + p.Nombre
                    })
                    .ToList();

                cboPacienteReporte.DataSource = null;
                cboPacienteReporte.DataSource = pacientes;
                cboPacienteReporte.DisplayMember = "NombreCompleto";
                cboPacienteReporte.ValueMember = "Id";
                cboPacienteReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los pacientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CARGAR PROFESIONALES EN EL COMBOBOX
        // ==========================================
        private void CargarProfesionales()
        {
            try
            {
                var profesionales = _context.Profesionales
                    .OrderBy(p => p.Apellido)
                    .ThenBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Id,
                        NombreCompleto = p.Apellido + ", " + p.Nombre
                    })
                    .ToList();

                cboProfesionalReporte.DataSource = null;
                cboProfesionalReporte.DataSource = profesionales;
                cboProfesionalReporte.DisplayMember = "NombreCompleto";
                cboProfesionalReporte.ValueMember = "Id";
                cboProfesionalReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los profesionales: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // CARGAR ESPECIALIDADES EN EL COMBOBOX
        // ==========================================
        private void CargarEspecialidades()
        {
            try
            {
                var especialidades = _context.Especialidades
                    .OrderBy(e => e.Nombre)
                    .Select(e => new
                    {
                        e.Id,
                        e.Nombre
                    })
                    .ToList();

                cboEspecialidadReporte.DataSource = null;
                cboEspecialidadReporte.DataSource = especialidades;
                cboEspecialidadReporte.DisplayMember = "Nombre";
                cboEspecialidadReporte.ValueMember = "Id";
                cboEspecialidadReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las especialidades: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REPORTE 1: PACIENTES
        // ==========================================
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var pacientes = _context.Pacientes
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Apellido,
                        p.DNI,
                        p.Telefono,
                        p.Email
                    })
                    .ToList();

                dgvReportes.DataSource = pacientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los pacientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REPORTE 2: PROFESIONALES CON ESPECIALIDAD
        // ==========================================
        private void BtnProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                var profesionales = _context.Profesionales
                    .Select(p => new
                    {
                        p.Id,
                        p.Nombre,
                        p.Apellido,
                        p.Matricula,
                        Especialidad = p.Especialidad.Nombre
                    })
                    .ToList();

                dgvReportes.DataSource = profesionales;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los profesionales: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REPORTE 3: TURNOS POR FECHA
        // ==========================================
        private void BtnTurnosFecha_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaSeleccionada = dtpFechaReporte.Value.Date;
                DateTime fechaSiguiente = fechaSeleccionada.AddDays(1);

                var turnos = _context.Turnos
                    .Where(t => t.Fecha >= fechaSeleccionada &&
                                t.Fecha < fechaSiguiente)
                    .Select(t => new
                    {
                        t.Id,
                        t.Fecha,
                        t.Hora,
                        Paciente = t.Paciente.Nombre + " " +
                                   t.Paciente.Apellido,
                        Profesional = t.Profesional.Nombre + " " +
                                      t.Profesional.Apellido,
                        t.Estado
                    })
                    .ToList();

                dgvReportes.DataSource = turnos;

                if (turnos.Count == 0)
                {
                    MessageBox.Show(
                        "No hay turnos registrados para esa fecha.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los turnos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REPORTE 4: TURNOS PENDIENTES
        // ==========================================
        private void BtnPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                var turnosPendientes = _context.Turnos
                    .Where(t => t.Estado == "Pendiente")
                    .OrderBy(t => t.Fecha)
                    .Select(t => new
                    {
                        t.Id,
                        t.Fecha,
                        t.Hora,
                        Paciente = t.Paciente.Nombre + " " +
                                   t.Paciente.Apellido,
                        Profesional = t.Profesional.Nombre + " " +
                                      t.Profesional.Apellido,
                        t.Estado
                    })
                    .ToList();

                // Ordenar por hora en memoria para evitar
                // problemas de TimeSpan en SQLite.
                var turnosOrdenados = turnosPendientes
                    .OrderBy(t => t.Fecha)
                    .ThenBy(t => t.Hora)
                    .ToList();

                dgvReportes.DataSource = turnosOrdenados;

                if (turnosOrdenados.Count == 0)
                {
                    MessageBox.Show(
                        "No hay turnos pendientes registrados.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los turnos pendientes: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REPORTE 5: HISTORIAL POR PACIENTE
        // ==========================================
        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            if (cboPacienteReporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Primero seleccioná un paciente.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int pacienteId =
                    Convert.ToInt32(cboPacienteReporte.SelectedValue);

                var historial = _context.Turnos
                    .Where(t => t.PacienteId == pacienteId)
                    .Select(t => new
                    {
                        t.Id,
                        t.Fecha,
                        t.Hora,
                        Profesional = t.Profesional.Nombre + " " +
                                      t.Profesional.Apellido,
                        t.Estado
                    })
                    .ToList()
                    .OrderBy(t => t.Fecha)
                    .ThenBy(t => t.Hora)
                    .ToList();

                dgvReportes.DataSource = historial;

                if (historial.Count == 0)
                {
                    MessageBox.Show(
                        "El paciente seleccionado no tiene turnos registrados.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el historial: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // EVENTO DEL TITULO
        // ==========================================
        private void Label1_Click(object sender, EventArgs e)
        {
        }

        // ==========================================
        // REPORTE 6: TURNOS POR PROFESIONAL
        // ==========================================
        private void btnTurnosProfesional_Click(object sender, EventArgs e)
        {
            if (cboProfesionalReporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Primero seleccioná un profesional.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DateTime desde = dtpDesdeReporte.Value.Date;
            DateTime hasta = dtpHastaReporte.Value.Date;

            if (desde > hasta)
            {
                MessageBox.Show(
                    "La fecha desde no puede ser posterior a la fecha hasta.",
                    "Fechas incorrectas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int profesionalId =
                    Convert.ToInt32(cboProfesionalReporte.SelectedValue);

                var turnos = _context.Turnos
                    .Where(t =>
                        t.ProfesionalId == profesionalId &&
                        t.Fecha >= desde &&
                        t.Fecha < hasta.AddDays(1))
                    .Select(t => new
                    {
                        t.Id,
                        t.Fecha,
                        t.Hora,
                        Paciente = t.Paciente.Nombre + " " +
                                   t.Paciente.Apellido,
                        Profesional = t.Profesional.Nombre + " " +
                                      t.Profesional.Apellido,
                        Especialidad = t.Profesional.Especialidad.Nombre,
                        t.Estado
                    })
                    .ToList()
                    .OrderBy(t => t.Fecha)
                    .ThenBy(t => t.Hora)
                    .ToList();

                dgvReportes.DataSource = turnos;

                if (turnos.Count == 0)
                {
                    MessageBox.Show(
                        "El profesional seleccionado no tiene turnos en ese período.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar los turnos por profesional: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // REPORTE 7: TURNOS POR ESPECIALIDAD
        // ==========================================
        private void btnTurnosEspecialidad_Click(object sender, EventArgs e)
        {
            if (cboEspecialidadReporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Primero seleccioná una especialidad.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int especialidadId =
                    Convert.ToInt32(cboEspecialidadReporte.SelectedValue);

                var turnos = _context.Turnos
                    .Where(t =>
                        t.Profesional.EspecialidadId == especialidadId)
                    .Select(t => new
                    {
                        t.Id,
                        t.Fecha,
                        t.Hora,
                        Paciente = t.Paciente.Nombre + " " +
                                   t.Paciente.Apellido,
                        Profesional = t.Profesional.Nombre + " " +
                                      t.Profesional.Apellido,
                        Especialidad = t.Profesional.Especialidad.Nombre,
                        t.Estado
                    })
                    .ToList()
                    .OrderBy(t => t.Fecha)
                    .ThenBy(t => t.Hora)
                    .ToList();

                dgvReportes.DataSource = turnos;

                if (turnos.Count == 0)
                {
                    MessageBox.Show(
                        "No hay turnos registrados para esta especialidad.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Cantidad de turnos encontrados: " + turnos.Count,
                        "Resultado del reporte",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al consultar los turnos por especialidad: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
