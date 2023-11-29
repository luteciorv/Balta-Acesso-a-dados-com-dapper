using Blog.Database;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens;

public static class UserScreen
{
    public static void Load()
    {
        Console.Clear();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("|| Gerenciamento de Usuários ||");
        Console.WriteLine("-------------------------------");

        Console.WriteLine("> O que deseja fazer?");
        Console.WriteLine("1 - Listar todos");
        Console.WriteLine("2 - Listar um em específico pelo Id");
        Console.WriteLine("3 - Cadastrar");
        Console.WriteLine("4 - Atualizar");
        Console.WriteLine("5 - Apagar");
        Console.WriteLine("6 - Vincular usuário a um perfil");
        Console.WriteLine("7 - Voltar");
        Console.WriteLine();
        Console.Write("Digite a sua resposta: ");
        var option = short.Parse(Console.ReadLine()!);

        Console.Clear();

        Console.WriteLine("------------------------------");
        Console.WriteLine("Gerenciamento de Usuários");
        Console.WriteLine("------------------------------");

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
                AssignToRole();
                break;

            case 7:
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
        var repository = new UserRepository(DataContext.Connection);
        var users = repository.GetWithRoles();

        Console.WriteLine(">> Listar usuários cadastrados:");
        foreach (var user in users)
        {
            Console.WriteLine($"- Id: {user.Id} \n" +
                              $"- Nome: {user.Name} \n" +
                              $"- E-mail: {user.Email}");

            var roles = "Nenhum perfil cadastrado";
            if (user.Roles.Count > 0)
            {
                roles = string.Empty;

                foreach (var role in user.Roles)
                    roles += $"{role.Name}, ";

                roles = roles.Remove(roles.Length - 2);
            }

            Console.WriteLine($"- Perfis: {roles}");
            Console.WriteLine();
        }

        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }

    private static void GetById()
    {
        var repository = new UserRepository(DataContext.Connection);

        Console.Write("Digite o Id do usuário: ");
        var id = int.Parse(Console.ReadLine()!);

        var user = repository.Get(id);
        if (user is null)
            Console.WriteLine($"Nenhum usuário com o id {id} foi encontrado");
        else
        {
            Console.WriteLine($"- Id: {user.Id} \n" +
                              $"- Nome: {user.Name} \n" +
                              $"- E-mail: {user.Email}");

            var roles = "Nenhum perfil cadastrado";
            if (user.Roles.Count > 0)
            {
                foreach (var role in user.Roles)
                    roles += $"{role.Name}, ";

                roles = roles.Remove(roles.Length - 2);
            }

            Console.WriteLine($"- Perfis: {roles}");
        }

        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }

    private static void Register()
    {
        var repository = new UserRepository(DataContext.Connection);

        Console.WriteLine(">> Cadastrar novo usuário:");
        Console.Write("Nome: ");
        var name = Console.ReadLine()!;

        Console.Write("E-mail: ");
        var email = Console.ReadLine()!;

        Console.Write("Senha: ");
        var password = Console.ReadLine()!;

        Console.Write("Biografia: ");
        var bio = Console.ReadLine()!;

        Console.Write("Link da imagem: ");
        var image = Console.ReadLine()!;

        var slug = name.Replace(' ', '-').ToLower();

        var user = new User
        {
            Name = name,
            Email = email,
            Bio = bio,
            PasswordHash = password,
            Image = image,
            Slug = slug
        };

        repository.Create(user);

        Console.WriteLine();
        Console.WriteLine("O usuário foi cadastrado com sucesso");
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

    private static void AssignToRole()
    {
        var userRepository = new UserRepository(DataContext.Connection);
        var roleRepository = new Repository<Role>(DataContext.Connection);

        Console.Write("Digite o Id do usuário: ");
        var userId = int.Parse(Console.ReadLine()!);
        
        var user = userRepository.Get(userId);
        if (user is null)
        {
            Console.WriteLine();
            Console.WriteLine($"Nenhum usuário com o id {userId} foi encontrado");
            Console.WriteLine("Aperte qualquer tecla para prosseguir...");
            Console.ReadKey();
            Load();
            return;
        }

        Console.Write("Digite o Id do perfil: ");
        var roleId = int.Parse(Console.ReadLine()!);

        var role = roleRepository.Get(roleId);
        if (role is null)
        {
            Console.WriteLine();
            Console.WriteLine($"Nenhum perfil com o id {roleId} foi encontrado");
            Console.WriteLine("Aperte qualquer tecla para prosseguir...");
            Console.ReadKey();
            Load();
            return;
        }

        userRepository.AssignToRole(userId, roleId);

        Console.WriteLine();
        Console.WriteLine("O usuário informado foi associdado ao perfil com sucesso");
        Console.WriteLine("Aperte qualquer tecla para prosseguir...");
        Console.ReadKey();
        Load();
    }
}