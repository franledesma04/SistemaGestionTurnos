

using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;
using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AppWinForms
{
    public partial class FrmEspecialidades : Form
    {
        private readonly ApplicationDbContext _context;

        // Constructor para el diseñador.
        public FrmEspecialidades()
        {
            InitializeComponent();
            _context = null!;
        }

        // Constructor utilizado por la aplicación.
        public FrmEspecialidades(ApplicationDbContext context)
        {
            InitializeComponent();

            _context = context;

            CargarEspecialidades();
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
                        e.Nombre,
                        e.Descripcion
                    })
                    .ToList();

                dgvEspecialidades.DataSource = especialidades;

                dgvEspecialidades.ReadOnly = true;
                dgvEspecialidades.AllowUserToAddRows = false;
                dgvEspecialidades.AllowUserToDeleteRows = false;
                dgvEspecialidades.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvEspecialidades.MultiSelect = false;
                dgvEspecialidades.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MostrarError("cargar las especialidades", ex);
            }
        }

        // =====================================
        // GUARDAR ESPECIALIDAD
        // =====================================

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Ingresá el nombre de la especialidad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombre.Focus();
                return;
            }

            try
            {
                bool existe = _context.Especialidades
                    .Any(e => e.Nombre.ToLower() == nombre.ToLower());

                if (existe)
                {
                    MessageBox.Show(
                        "Ya existe una especialidad con ese nombre.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var especialidad = new Especialidad
                {
                    Nombre = nombre,
                    Descripcion = descripcion
                };

                _context.Especialidades.Add(especialidad);
                _context.SaveChanges();

                MessageBox.Show(
                    "Especialidad registrada correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarEspecialidades();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se pudo guardar la especialidad. Verificá que no exista otra con el mismo nombre.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MostrarError("guardar la especialidad", ex);
            }
        }

        // =====================================
        // ELIMINAR ESPECIALIDAD
        // =====================================

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccioná una especialidad de la grilla.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int especialidadId = Convert.ToInt32(
                dgvEspecialidades.SelectedRows[0].Cells["Id"].Value);

            try
            {
                // Comprobar si existen profesionales asociados.
                bool tieneProfesionales = _context.Profesionales
                    .AsNoTracking()
                    .Any(p => p.EspecialidadId == especialidadId);

                if (tieneProfesionales)
                {
                    MessageBox.Show(
                        "No se puede eliminar esta especialidad porque tiene profesionales asociados. Primero debés quitar o reasignar esos profesionales.",
                        "Eliminación no permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var respuesta = MessageBox.Show(
                    "¿Estás seguro de que querés eliminar la especialidad seleccionada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                var especialidad = _context.Especialidades
                    .FirstOrDefault(e => e.Id == especialidadId);

                if (especialidad == null)
                {
                    MessageBox.Show(
                        "No se encontró la especialidad seleccionada.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                _context.Especialidades.Remove(especialidad);
                _context.SaveChanges();

                MessageBox.Show(
                    "Especialidad eliminada correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarEspecialidades();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "No se pudo eliminar la especialidad porque existen registros relacionados.",
                    "Eliminación no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MostrarError("eliminar la especialidad", ex);
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
        }

        // =====================================
        // LIMPIAR CAMPOS
        // =====================================

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();

            dgvEspecialidades.ClearSelection();

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
