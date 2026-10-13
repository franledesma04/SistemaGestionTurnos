namespace AccesoDatos.Modelos;

public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public string DNI { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime FechaNacimiento { get; set; }

    public List<Turno> Turnos { get; set; } = new();
}