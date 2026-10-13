namespace AccesoDatos.Modelos;

public class Profesional
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string Matricula { get; set; } = "";

    public int EspecialidadId { get; set; }
    public Especialidad Especialidad { get; set; } = null!;

    public List<Turno> Turnos { get; set; } = new();
}