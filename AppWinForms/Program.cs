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

            // Crear el contenedor
            var services = new ServiceCollection();

            // Registrar el contexto de base de datos
            services.AddDbContext<ApplicationDbContext>();

            // Registrar el repositorio de pacientes
            services.AddScoped<
                IGenericRepository<Paciente>,
                Repositorio<Paciente>>();

            // Registrar los formularios
            services.AddTransient<FrmPacientes>();
            services.AddTransient<FrmEspecialidades>();
            services.AddTransient<FrmProfesionales>();
            services.AddTransient<FrmTurnos>();
            services.AddTransient<FrmReportes>();

            // Construir el proveedor
            using var serviceProvider =
                services.BuildServiceProvider();

            // Crear un alcance
            using var scope =
                serviceProvider.CreateScope();

            // Obtener el formulario inicial
            var formulario =
                scope.ServiceProvider
                    .GetRequiredService<FrmPacientes>();

            // Ejecutar la aplicación
            Application.Run(formulario);
        }
    }
}



