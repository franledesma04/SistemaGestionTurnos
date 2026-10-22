using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;

namespace AppWinForms
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();

            // Cargar pacientes al abrir el formulario.
            CargarPacientes();
        }

        // CARGAR PACIENTES EN EL COMBOBOX
        private void CargarPacientes()
        {
            try
            {
                using var db = new ApplicationDbContext();

                var pacientes = db.Pacientes
                    .OrderBy(p => p.Apellido)
                    .ThenBy(p => p.Nombre)
                    .Select(p => new
                    {
                        p.Id,
                        NombreCompleto = p.Apellido + ", " + p.Nombre
                    })
                    .ToList();

                cboPacienteReporte.DataSource = pacientes;
                cboPacienteReporte.DisplayMember = "NombreCompleto";
                cboPacienteReporte.ValueMember = "Id";
                cboPacienteReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la lista de pacientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // REPORTE 1: PACIENTES
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new ApplicationDbContext();

                var pacientes = db.Pacientes
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
                    MessageBoxIcon.Error
                );
            }
        }

        // REPORTE 2: PROFESIONALES CON ESPECIALIDAD
        private void btnProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new ApplicationDbContext();

                var profesionales = db.Profesionales
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
                    MessageBoxIcon.Error
                );
            }
        }

        // REPORTE 3: TURNOS POR FECHA
        private void btnTurnosFecha_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new ApplicationDbContext();

                DateTime fechaSeleccionada = dtpFechaReporte.Value.Date;
                DateTime fechaSiguiente = fechaSeleccionada.AddDays(1);

                var turnos = db.Turnos
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
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los turnos: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // REPORTE 4: TURNOS PENDIENTES
        private void btnPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new ApplicationDbContext();

                var turnosPendientes = db.Turnos
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
                // el error de TimeSpan en SQLite.
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
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los turnos pendientes: " +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // REPORTE 5: HISTORIAL POR PACIENTE
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (cboPacienteReporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Primero seleccioná un paciente.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                int pacienteId =
                    Convert.ToInt32(cboPacienteReporte.SelectedValue);

                using var db = new ApplicationDbContext();

                var historial = db.Turnos
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
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el historial: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // EVENTO DEL TITULO
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}