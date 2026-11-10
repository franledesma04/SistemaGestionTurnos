
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

using AccesoDatos.Datos;
using AccesoDatos.Modelos;
using AccesoDatos.Repositorios;

namespace AppWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // Base de datos
            services.AddDbContext<ApplicationDbContext>();

            // Repositorio de pacientes
            services.AddScoped<
                IGenericRepository<Paciente>,
                Repositorio<Paciente>>();

            // Formularios
            services.AddTransient<FrmMenu>();
            services.AddTransient<FrmPacientes>();
            services.AddTransient<FrmProfesionales>();
            services.AddTransient<FrmEspecialidades>();
            services.AddTransient<FrmTurnos>();
            services.AddTransient<FrmReportes>();

            // Crear proveedor
            using var serviceProvider =
                services.BuildServiceProvider();

            // Crear alcance
            using var scope =
                serviceProvider.CreateScope();

            // Obtener menú principal
            var formulario =
                scope.ServiceProvider
                    .GetRequiredService<FrmMenu>();

            // Iniciar aplicación
            Application.Run(formulario);
        }
    }
}




