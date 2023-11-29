using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<TModel>(SqlConnection connection) where TModel : class
{
    protected readonly SqlConnection _connection = connection;

    public IEnumerable<TModel> Get()
       => _connection.GetAll<TModel>();

    public TModel Get(int id)
       => _connection.Get<TModel>(id);

    public void Create(TModel model)
        => _connection.Insert(model);

    public void Update(TModel model) 
        => _connection.Update(model);

    public void Delete(TModel model)
        => _connection.Delete(model);

    public void Delete(int id)
    {
        var model = _connection.Get<TModel>(id);
        _connection.Delete(model);
    }
}
