namespace AccesoDatos.Modelos;

public class Turno
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }
    public string Estado { get; set; } = "Pendiente";

    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; } = null!;

    public int ProfesionalId { get; set; }
    public Profesional Profesional { get; set; } = null!;
}