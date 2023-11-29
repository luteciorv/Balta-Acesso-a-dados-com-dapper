namespace Blog.Screens;

public static class MenuScreen
{
    public static void Load()
    {
        Console.Clear();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("||   Gerenciamento do Blog   ||");
        Console.WriteLine("-------------------------------");

        Console.WriteLine(">> O que deseja fazer?");
        Console.WriteLine("1 - Usuários");
        Console.WriteLine("2 - Perfis");
        Console.WriteLine("3 - Categorias");
        Console.WriteLine("4 - Posts");
        Console.WriteLine("5 - Tags");
        Console.WriteLine("6 - Finalizar");
        Console.WriteLine();
        Console.Write("Digite a sua resposta: ");
        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1:
                UserScreen.Load();
                break;

            case 2:
                RoleScreen.Load();
                break;

            case 3:
                CategoryScreen.Load();
                break;

            case 4:
                PostScreen.Load();
                break;

            case 5:
                TagScreen.Load();
                break;
            
            case 6:
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Selecione uma opção entre 1 e 6");
                Console.ReadKey();
                Load();
                break;
        }
    }
}
