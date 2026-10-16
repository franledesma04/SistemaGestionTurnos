using AccesoDatos.Datos;
using Microsoft.EntityFrameworkCore;

namespace AppWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // Crea la base de datos y aplica las migraciones pendientes
                using (var db = new ApplicationDbContext())
                {
                    db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar la base de datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmPacientes());
        }
    }
}