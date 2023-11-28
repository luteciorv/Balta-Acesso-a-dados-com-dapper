// See https://aka.ms/new-console-template for more information
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = 

using var connection = new SqlConnection(CONNECTION_STRING);

//CreateUser(connection);
//UpdateUser(connection);
//DeleteUser(connection);
ReadUsers(connection);

static void ReadUsers(SqlConnection connection)
{
    var repository = new UserRepository();
    var users = repository.Get(connection);

    foreach (var user in users)
        Console.WriteLine("");
}

static void ReadUser(SqlConnection connection)
{
    var user = connection.Get<User>(1);
    Console.WriteLine(user.Name);
}

static void CreateUser(SqlConnection connection)
{
    var user = new User
    {
        Name = "Equipe Balta IO",
        PasswordHash = "Hash",
        Bio = "Equipe Balta IO",
        Email = "equipe@localhost.com",
        Image = "https://...",
        Slug = "balta-io"
    };

    connection.Insert(user);
    Console.WriteLine("Usuário cadastrado com sucesso");
}

static void UpdateUser(SqlConnection connection)
{
    var user = new User
    {
        Id = 3,
        Name = "Equipe | Balta IO",
        PasswordHash = "Hash",
        Bio = "Equipe Balta.IO",
        Email = "equipe@localhost.com",
        Image = "https://...",
        Slug = "equipe-balta-io"
    };

    connection.Update(user);
    Console.WriteLine("Usuário atualizado com sucesso");
}

static void DeleteUser(SqlConnection connection)
{
    var user = connection.Get<User>(3);
    connection.Delete(user);

    Console.WriteLine("O usuário foi apagado com sucesso");
}