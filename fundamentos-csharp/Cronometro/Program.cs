Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("S - Segundo => 10s = 10 segundos\nM - Minuto => 1m = 1 minuto\n0 - Sair");

    Console.WriteLine("Quanto tempo deseja contar?");
    var tempoInformado = Console.ReadLine()?.ToLower();
    var tipo = tempoInformado != null && tempoInformado.Equals("0") ? "0" : tempoInformado?.Substring(tempoInformado.Length - 1, 1);
    var tempo = tempoInformado?[..^1] != null && tipo != "0" ? int.Parse(tempoInformado[..^1]) : 0;

    switch (tipo)
    {
        case "s":
            PreStart(tempo);
            break;
        case "m":
            PreStart(ConverterMinutoParaSegundo(tempo));
            break;
        case "0":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Tipo inválido.");
            break;
    }
}

static int ConverterMinutoParaSegundo(int minuto)
{
    return minuto * 60;
}

static void PreStart(int tempo)
{
    Console.Clear();
    Console.WriteLine("Preparar...");
    Thread.Sleep(1000);

    Console.WriteLine("Apontar...");
    Thread.Sleep(1000);

    Console.WriteLine("Fogo...");
    Thread.Sleep(2500);

    Start(tempo);
}

static void Start(int tempo)
{
    int tempoAtual = 0;

    while (tempoAtual < tempo)
    {
        Console.Clear();
        tempoAtual++;
        Console.WriteLine(tempoAtual);
        Thread.Sleep(1000);
    }

    Console.Clear();
    Console.WriteLine("Cronomêtro finalizado!");
    Thread.Sleep(2500);
    Menu();
}