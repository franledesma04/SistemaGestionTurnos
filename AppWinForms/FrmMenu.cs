
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace AppWinForms
{
    public partial class FrmMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;

        // Constructor para el diseñador de Visual Studio
        public FrmMenu()
        {
            InitializeComponent();
        }

        // Constructor utilizado por la aplicación
        public FrmMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmPacientes>();
        }

        private void btnProfesionales_Click(object sender, EventArgs e)
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
            T formulario = _serviceProvider.GetRequiredService<T>();

            using (formulario)
            {
                formulario.ShowDialog(this);
            }
        }
    }
}

