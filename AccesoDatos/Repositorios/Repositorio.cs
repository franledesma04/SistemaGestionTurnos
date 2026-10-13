using AccesoDatos.Datos;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositorios;

public class Repositorio<T> where T : class
{
    public List<T> ObtenerTodos()
    {
        using var db = new ApplicationDbContext();

        return db.Set<T>()
            .AsNoTracking()
            .ToList();
    }

    public T? ObtenerPorId(int id)
    {
        using var db = new ApplicationDbContext();
        return db.Set<T>().Find(id);
    }

    public void Agregar(T entidad)
    {
        using var db = new ApplicationDbContext();

        db.Set<T>().Add(entidad);
        db.SaveChanges();
    }

    public void Modificar(T entidad)
    {
        using var db = new ApplicationDbContext();

        db.Set<T>().Update(entidad);
        db.SaveChanges();
    }

    public void Eliminar(int id)
    {
        using var db = new ApplicationDbContext();

        var entidad = db.Set<T>().Find(id);

        if (entidad is null)
            return;

        db.Set<T>().Remove(entidad);
        db.SaveChanges();
    }
}