Menu();

static void Menu()
{
    Console.Clear();

    Console.WriteLine("Qual operação deseja realizar?");
    Console.WriteLine("1 - Soma\n2 - Subtração\n3 - Divisão\n4 - Multiplicação\n5 - Sair");

    Console.WriteLine("*************************");
    Console.WriteLine("Informe a opção desejada:");
    short operacaoDesejada = Convert.ToInt16(Console.ReadLine());

    RealizarCalculo(operacaoDesejada);
}

static void RealizarCalculo(short operacaoDesejada)
{
    if (operacaoDesejada == 5)
    {
        Environment.Exit(0);
    }

    Console.Clear();

    Console.WriteLine("Informe o primeiro valor:");
    double primeiroValor = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Informe o segundo valor:");
    double segundoValor = Convert.ToDouble(Console.ReadLine());

    switch (operacaoDesejada)
    {
        case 1:
            Soma(primeiroValor, segundoValor);
            break;
        case 2:
            Subtracao(primeiroValor, segundoValor);
            break;
        case 3:
            Divisao(primeiroValor, segundoValor);
            break;
        case 4:
            Multiplicacao(primeiroValor, segundoValor);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

static void Soma(double primeiroValor, double segundoValor)
{
    Console.WriteLine($"\nResultado da soma: {primeiroValor + segundoValor}");
    Console.ReadKey();
    Menu();
}

static void Subtracao(double primeiroValor, double segundoValor)
{
    Console.WriteLine($"\nResultado da subtração: {primeiroValor - segundoValor}");
    Console.ReadKey();
    Menu();
}

static void Divisao(double primeiroValor, double segundoValor)
{
    if (segundoValor > 0)
    {
        Console.WriteLine($"\nResultado da divisão: {primeiroValor / segundoValor}");
        Console.ReadKey();
        Menu();
    }
    else
    {
        Console.WriteLine("\nNão é possível realizar divisão por 0!");
        Console.ReadKey();
        Menu();
    }
}

static void Multiplicacao(double primeiroValor, double segundoValor)
{
    Console.WriteLine($"\nResultado da multiplicação: {primeiroValor * segundoValor}");
    Console.ReadKey();
    Menu();
}