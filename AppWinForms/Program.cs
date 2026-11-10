
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

            // Registrar el contexto de base de datos.
            services.AddDbContext<ApplicationDbContext>();

            // Registrar el repositorio de pacientes.
            services.AddScoped<
                IGenericRepository<Paciente>,
                Repositorio<Paciente>>();

            // Registrar los formularios.
            services.AddTransient<FrmMenu>();
            services.AddTransient<FrmPacientes>();
            services.AddTransient<FrmProfesionales>();
            services.AddTransient<FrmEspecialidades>();
            services.AddTransient<FrmTurnos>();
            services.AddTransient<FrmReportes>();

            // Crear el proveedor de dependencias.
            using var serviceProvider =
                services.BuildServiceProvider();

            // Obtener el menú principal.
            var formulario =
                serviceProvider.GetRequiredService<FrmMenu>();

            // Iniciar la aplicación.
            Application.Run(formulario);
        }
    }
}




