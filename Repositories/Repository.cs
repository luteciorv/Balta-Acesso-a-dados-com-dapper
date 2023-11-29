using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories;

public class Repository<TModel>(SqlConnection connection) where TModel : class
{
    protected readonly SqlConnection Connection = connection;

    public IEnumerable<TModel> Get()
       => Connection.GetAll<TModel>();

    public TModel Get(int id)
       => Connection.Get<TModel>(id);

    public void Create(TModel model)
        => Connection.Insert(model);

    public void Update(TModel model) 
        => Connection.Update(model);

    public void Delete(TModel model)
        => Connection.Delete(model);

    public void Delete(int id)
    {
        var model = Connection.Get<TModel>(id);
        Connection.Delete(model);
    }
}
