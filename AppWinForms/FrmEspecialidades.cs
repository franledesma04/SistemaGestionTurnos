
using System;
using System.Linq;
using System.Windows.Forms;
using AccesoDatos.Datos;
using AccesoDatos.Modelos;

namespace AppWinForms
{
    public partial class FrmEspecialidades : Form
    {
        public FrmEspecialidades()
        {
            InitializeComponent();
            CargarEspecialidades();
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
                        e.Nombre,
                        e.Descripcion
                    })
                    .ToList();

                dgvEspecialidades.DataSource = especialidades;
            }
            catch (Exception ex)
            {
                MostrarError("cargar las especialidades", ex);
            }
        }

        // =====================================
        // GUARDAR ESPECIALIDAD
        // =====================================

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
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
                using var db = new ApplicationDbContext();

                bool existe = db.Especialidades
                    .Any(e => e.Nombre.ToLower() ==
                              nombre.ToLower());

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

                db.Especialidades.Add(especialidad);
                db.SaveChanges();

                MessageBox.Show(
                    "Especialidad registrada correctamente.",
                    "Guardado exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();
                CargarEspecialidades();
            }
            catch (Exception ex)
            {
                MostrarError("guardar la especialidad", ex);
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
        }

        // =====================================
        // LIMPIAR CAMPOS
        // =====================================

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
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

