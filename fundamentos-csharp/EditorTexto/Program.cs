Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir arquivo\n2 - Criar novo arquivo\n0 - Sair");

    short option = Convert.ToInt16(Console.ReadLine());

    switch (option)
    {
        case 0:
            System.Environment.Exit(0);
            break;
        case 1:
            Abrir();
            break;
        case 2:
            Editar();
            break;
        default:
            Menu();
            break;
    }
}

static void Abrir()
{
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");
    var caminho = Console.ReadLine();

    if (string.IsNullOrEmpty(caminho))
    {
        Console.WriteLine("O caminho não pode ser nulo!");
    }
    else
    {
        using (var arquivo = new StreamReader(caminho))
        {
            var texto = arquivo.ReadToEnd();
            Console.WriteLine(texto);
        }

        Console.WriteLine("");
        Console.ReadLine();

        Menu();
    }
}

static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo: (ESC para sair)\n");
    Console.WriteLine("---------------------");

    string texto = string.Empty;

    do
    {
        texto += Console.ReadLine();
        texto += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(texto);
}

static void Salvar(string texto)
{
    Console.Clear();
    Console.WriteLine("Qual o caminho para salvar o caminho?");
    var caminho = Console.ReadLine();

    if (string.IsNullOrEmpty(caminho))
    {
        Console.WriteLine("O caminho não pode ser nulo.");
    }
    else
    {
        using (var arquivo = new StreamWriter(caminho))
        {
            arquivo.WriteLine(texto);
        }

        Console.WriteLine($"Arquivo {caminho} salvo com sucesso!");
        Console.ReadLine();
    }

    Menu();
}