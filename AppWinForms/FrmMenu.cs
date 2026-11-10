

using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace AppWinForms
{
    public partial class FrmMenu : Form
    {
        private readonly IServiceScopeFactory _scopeFactory;

        // Constructor para el diseñador.
        public FrmMenu()
        {
            InitializeComponent();
            _scopeFactory = null!;
        }

        // Constructor utilizado por la aplicación.
        public FrmMenu(IServiceScopeFactory scopeFactory)
        {
            InitializeComponent();
            _scopeFactory = scopeFactory;
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmPacientes>();
        }

        private void BtnProfesionales_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmProfesionales>();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmEspecialidades>();
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmTurnos>();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmReportes>();
        }

        private void AbrirFormulario<T>() where T : Form
        {
            // Crear un alcance independiente.
            using var scope = _scopeFactory.CreateScope();

            // Obtener el formulario desde ese alcance.
            var formulario =
                scope.ServiceProvider.GetRequiredService<T>();

            // Mantener el alcance activo mientras el formulario esté abierto.
            using (formulario)
            {
                formulario.ShowDialog(this);
            }
        }
    }
}


