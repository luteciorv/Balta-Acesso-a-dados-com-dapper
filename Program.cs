// See https://aka.ms/new-console-template for more information
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=Teste@123;Trusted_Connection=False;TrustServerCertificate=True;";

using var connection = new SqlConnection(CONNECTION_STRING);

ReadUsers(connection);
ReadRoles(connection);
ReadTags(connection);

static void ReadUsers(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var users = repository.GetWithRoles();

    Console.WriteLine("\nUsuários:");
    foreach (var user in users)
    {
        Console.WriteLine("- " + user.Name);

        foreach(var role in user.Roles)
            Console.WriteLine("..Role: " + role.Name);

        Console.WriteLine();
    }
}

static void ReadUser(SqlConnection connection)
{
    var user = connection.Get<User>(1);
    Console.WriteLine(user.Name);
}

static void ReadRoles(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var roles = repository.Get();

    Console.WriteLine("Roles:");
    foreach (var role in roles)
        Console.WriteLine("- " + role.Name);

    Console.WriteLine();
}

static void ReadTags(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
    var tags = repository.Get();

    Console.WriteLine("Tags:");
    foreach (var tag in tags)
        Console.WriteLine(tag.Name);

    Console.WriteLine();
}