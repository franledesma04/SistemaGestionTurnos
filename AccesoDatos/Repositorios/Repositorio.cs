
using AccesoDatos.Datos;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositorios;

public class Repositorio<T> : IGenericRepository<T>
    where T : class
{
    private readonly ApplicationDbContext _context;

    public Repositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<T> ObtenerTodos()
    {
        return _context.Set<T>()
            .AsNoTracking()
            .ToList();
    }

    public T? ObtenerPorId(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Agregar(T entidad)
    {
        _context.Set<T>().Add(entidad);
        _context.SaveChanges();
    }

    public void Modificar(T entidad)
    {
        _context.Set<T>().Update(entidad);
        _context.SaveChanges();
    }

    public void Eliminar(T entidad)
    {
        _context.Set<T>().Remove(entidad);
        _context.SaveChanges();
    }
}
