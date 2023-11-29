using Blog.Database;
using Blog.Models;
using Blog.Repositories;
using System.Data;

namespace Blog.Screens;

public class RoleScreen
{
    public static void Load()
    {
        Console.Clear();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("|| Gerenciamento de Perfis ||");
        Console.WriteLine("-------------------------------");

        Console.WriteLine("> O que deseja fazer?");
        Console.WriteLine("1 - Listar todos");
        Console.WriteLine("2 - Listar um em específico pelo Id");
        Console.WriteLine("3 - Cadastrar");
        Console.WriteLine("4 - Atualizar");
        Console.WriteLine("5 - Apagar");
        Console.WriteLine("6 - Voltar");
        Console.WriteLine();
        Console.Write("Digite a sua resposta: ");
        var option = short.Parse(Console.ReadLine()!);

        Console.Clear();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("|| Gerenciamento de Perfis ||");
        Console.WriteLine("-------------------------------");

        switch (option)
        {
            case 1:
                GetAll();
                break;

            case 2:
                GetById();
                break;

            case 3:
                Register();
                break;

            case 4:
                Update();
                break;

            case 5:
                Delete();
                break;

            case 6:
                MenuScreen.Load();
                break;

            default:
                Console.WriteLine("Selecione uma opção entre 1 e 6");
                Console.ReadKey();
                Load();
                break;
        }
    }

    private static void GetAll()
    {
        var repository = new Repository<Role>(DataContext.Connection);
        var roles = repository.Get();

        Console.WriteLine(">> Listar perfis cadastrados:");
        foreach (var role in roles)
        {
            Console.WriteLine($"- Id: {role.Id} \n" +
                              $"- Nome: {role.Name}");

            Console.WriteLine();
        }

        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }

    private static void GetById()
    {
        var repository = new Repository<Role>(DataContext.Connection);
       
        Console.Write("Digite o Id do perfil: ");
        var id = int.Parse(Console.ReadLine()!);

        var role = repository.Get(id);

        Console.WriteLine();

        if (role is null)
            Console.WriteLine($"Nenhum perfil com o id {id} foi encontrado");
        else
        {
            Console.WriteLine(">> Perfil:");
            Console.WriteLine($"- Id: {role.Id} \n" +
                              $"- Nome: {role.Name}");
        }

        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }

    private static void Register()
    {
        var repository = new Repository<Role>(DataContext.Connection);

        Console.WriteLine(">> Cadastrar novo perfil:");
        Console.Write("Nome: ");
        var name = Console.ReadLine()!;

        var slug = name.ToLower();

        var role = new Role
        {
            Name = name,
            Slug = slug
        };

        repository.Create(role);

        Console.WriteLine();
        Console.WriteLine("O perfil foi cadastrado com sucesso");
        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }

    private static void Update()
    {
        Console.WriteLine("Função ainda não implementada...");
        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }

    private static void Delete()
    {
        Console.WriteLine("Função ainda não implementada...");
        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }
}