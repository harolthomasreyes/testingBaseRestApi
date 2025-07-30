namespace Repository.GenericRepository;


using System.Collections.Generic;
using System.Linq;
using Repository.Interface;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly List<T> _entities = new List<T>();

    public IEnumerable<T> GetAll()
    {
        return _entities;
    }

    public T GetById(int id)
    {
        var property = typeof(T).GetProperty("Id");
        return _entities.FirstOrDefault(e => property != null && (int)property.GetValue(e) == id);
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        var property = typeof(T).GetProperty("Id");
        if (property == null) return;

        int id = (int)property.GetValue(entity);
        var existing = GetById(id);
        if (existing != null)
        {
            _entities.Remove(existing);
            _entities.Add(entity);
        }
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _entities.Remove(entity);
        }
    }
}