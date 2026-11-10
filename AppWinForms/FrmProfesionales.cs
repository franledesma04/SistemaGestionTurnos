

using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;
using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppWinForms
{
    public partial class FrmProfesionales : Form
    {
        private readonly ApplicationDbContext _context;

        // Constructor para el diseñador.
        public FrmProfesionales()
        {
            InitializeComponent();
            _context = null!;
        }

        // Constructor utilizado por la aplicación.
        public FrmProfesionales(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;

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
                var especialidades = _context.Especialidades
                    .AsNoTracking()
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
                var profesionales = _context.Profesionales
                    .AsNoTracking()
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

                dgvProfesionales.ReadOnly = true;
                dgvProfesionales.AllowUserToAddRows = false;
                dgvProfesionales.AllowUserToDeleteRows = false;
                dgvProfesionales.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvProfesionales.MultiSelect = false;
                dgvProfesionales.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MostrarError("cargar profesionales", ex);
            }
        }

        // =====================================
        // GUARDAR PROFESIONAL
        // =====================================

        private void btnGuardar_Click(object sender, EventArgs e)
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

                // Verificar que la matrícula no esté repetida.
                bool matriculaExiste = _context.Profesionales
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

                // Verificar que la especialidad exista.
                bool especialidadExiste = _context.Especialidades
                    .Any(e => e.Id == especialidadId);

                if (!especialidadExiste)
                {
                    MessageBox.Show(
                        "La especialidad seleccionada ya no existe.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CargarEspecialidades();
                    return;
                }

                var profesional = new Profesional
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Matricula = matricula,
                    EspecialidadId = especialidadId
                };

                _context.Profesionales.Add(profesional);
                _context.SaveChanges();

                MessageBox.Show(
                    "Profesional registrado correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProfesionales();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se pudo guardar el profesional. Verificá que la matrícula no esté repetida.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MostrarError("guardar el profesional", ex);
            }
        }

        // =====================================
        // ELIMINAR PROFESIONAL
        // =====================================

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProfesionales.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccioná un profesional de la grilla.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int profesionalId = Convert.ToInt32(
                dgvProfesionales.SelectedRows[0].Cells["Id"].Value);

            // Comprobar si tiene turnos asociados.
            bool tieneTurnos = _context.Turnos
                .AsNoTracking()
                .Any(t => t.ProfesionalId == profesionalId);

            if (tieneTurnos)
            {
                MessageBox.Show(
                    "No se puede eliminar el profesional porque tiene turnos asociados.",
                    "Eliminación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var respuesta = MessageBox.Show(
                "¿Estás seguro de que querés eliminar el profesional seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                var profesional = _context.Profesionales
                    .FirstOrDefault(p => p.Id == profesionalId);

                if (profesional == null)
                {
                    MessageBox.Show(
                        "No se encontró el profesional seleccionado.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                _context.Profesionales.Remove(profesional);
                _context.SaveChanges();

                MessageBox.Show(
                    "Profesional eliminado correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarProfesionales();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se pudo eliminar el profesional porque tiene registros relacionados.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MostrarError("eliminar el profesional", ex);
            }
        }

        // =====================================
        // BOTÓN NUEVO
        // =====================================

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // =====================================
        // BOTÓN ACTUALIZAR
        // =====================================

        private void btnActualizar_Click(object sender, EventArgs e)
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

            dgvProfesionales.ClearSelection();

            txtNombre.Focus();
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
