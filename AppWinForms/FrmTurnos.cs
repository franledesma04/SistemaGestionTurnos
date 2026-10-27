

using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;
using AccesoDatos.Modelos;

namespace AppWinForms
{
    public partial class FrmTurnos : Form
    {
        public FrmTurnos()
        {
            InitializeComponent();

            cboEstado.SelectedIndex = 0;
            dtpFecha.MinDate = DateTime.Today;

            CargarPacientes();
            CargarProfesionales();
            CargarTurnos();
        }

        // =====================================
        // CARGAR PACIENTES
        // =====================================

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
                using var db = new ApplicationDbContext();

                var profesionales = db.Profesionales
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
                using var db = new ApplicationDbContext();

                var turnos = db.Turnos
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
            }
            catch (Exception ex)
            {
                MostrarError("cargar turnos", ex);
            }
        }

        // =====================================
        // GUARDAR TURNO EN SQLITE
        // =====================================

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
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

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;

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
                int pacienteId =
                    Convert.ToInt32(cboPaciente.SelectedValue);

                int profesionalId =
                    Convert.ToInt32(cboProfesional.SelectedValue);

                string estado =
                    cboEstado.SelectedItem?.ToString()
                    ?? "Pendiente";

                using var db = new ApplicationDbContext();

                var turno = new Turno
                {
                    PacienteId = pacienteId,
                    ProfesionalId = profesionalId,
                    Fecha = fecha,
                    Hora = hora,
                    Estado = estado
                };

                db.Turnos.Add(turno);
                db.SaveChanges();

                MessageBox.Show(
                    "Turno registrado correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarTurnos();

                cboPaciente.SelectedIndex = -1;
                cboProfesional.SelectedIndex = -1;
                cboEstado.SelectedIndex = 0;
                dtpFecha.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MostrarError("guardar el turno", ex);
            }
        }

        // =====================================
        // ACTUALIZAR LISTA
        // =====================================

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            CargarPacientes();
            CargarProfesionales();
            CargarTurnos();
        }

        // =====================================
        // MOSTRAR ERRORES
        // =====================================

        private void MostrarError(
            string operacion,
            Exception ex)
        {
            MessageBox.Show(
                "Error al " + operacion + ": " + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}

