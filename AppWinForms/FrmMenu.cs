using System;
using System.Windows.Forms;

namespace AppWinForms
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            using (FrmPacientes formulario = new FrmPacientes())
            {
                formulario.ShowDialog(this);
            }
        }

        private void btnProfesionales_Click(object sender, EventArgs e)
        {
            using (FrmProfesionales formulario = new FrmProfesionales())
            {
                formulario.ShowDialog(this);
            }
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            using (FrmEspecialidades formulario = new FrmEspecialidades())
            {
                formulario.ShowDialog(this);
            }
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            using (FrmTurnos formulario = new FrmTurnos())
            {
                formulario.ShowDialog(this);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using (FrmReportes formulario = new FrmReportes())
            {
                formulario.ShowDialog(this);
            }
        }
    }
}
