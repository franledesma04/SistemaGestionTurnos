
using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;
using AccesoDatos.Modelos;

namespace AppWinForms
{
    public partial class FrmProfesionales : Form
    {
        public FrmProfesionales()
        {
            InitializeComponent();

            CargarEspecialidades();
            CargarProfesionales();
        }

        // =====================================
        // CARGAR ESPECIALIDADES
        // =====================================

        private void CargarEspecialidades()
        {
            try
            {
                using var db = new ApplicationDbContext();

                var especialidades = db.Especialidades
                    .OrderBy(e => e.Nombre)
                    .Select(e => new
                    {
                        e.Id,
                        e.Nombre
                    })
                    .ToList();

                cboEspecialidad.DataSource = especialidades;
                cboEspecialidad.DisplayMember = "Nombre";
                cboEspecialidad.ValueMember = "Id";
                cboEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("cargar especialidades", ex);
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
                        p.Nombre,
                        p.Apellido,
                        p.Matricula,
                        Especialidad = p.Especialidad.Nombre
                    })
                    .ToList();

                dgvProfesionales.DataSource = profesionales;
            }
            catch (Exception ex)
            {
                MostrarError("cargar profesionales", ex);
            }
        }

        // =====================================
        // GUARDAR PROFESIONAL
        // =====================================

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string matricula = txtMatricula.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Ingresá el nombre del profesional.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show(
                    "Ingresá el apellido del profesional.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matricula))
            {
                MessageBox.Show(
                    "Ingresá la matrícula del profesional.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMatricula.Focus();
                return;
            }

            if (cboEspecialidad.SelectedIndex < 0 ||
                cboEspecialidad.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccioná una especialidad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int especialidadId = Convert.ToInt32(
                    cboEspecialidad.SelectedValue);

                using var db = new ApplicationDbContext();

                bool matriculaExiste = db.Profesionales
                    .Any(p => p.Matricula == matricula);

                if (matriculaExiste)
                {
                    MessageBox.Show(
                        "Ya existe un profesional con esa matrícula.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var profesional = new Profesional
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Matricula = matricula,
                    EspecialidadId = especialidadId
                };

                db.Profesionales.Add(profesional);
                db.SaveChanges();

                MessageBox.Show(
                    "Profesional registrado correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProfesionales();
            }
            catch (Exception ex)
            {
                MostrarError("guardar el profesional", ex);
            }
        }

        // =====================================
        // BOTÓN NUEVO
        // =====================================

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        // =====================================
        // BOTÓN ACTUALIZAR
        // =====================================

        private void btnActualizar_Click(
            object sender,
            EventArgs e)
        {
            CargarEspecialidades();
            CargarProfesionales();
        }

        // =====================================
        // LIMPIAR CAMPOS
        // =====================================

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtMatricula.Clear();
            cboEspecialidad.SelectedIndex = -1;
            txtNombre.Focus();
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

