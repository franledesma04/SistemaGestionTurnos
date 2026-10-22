using System;
using System.Windows.Forms;

namespace AppWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Abrir el formulario de reportes
            Application.Run(new FrmPacientes());
        }
    }
}   