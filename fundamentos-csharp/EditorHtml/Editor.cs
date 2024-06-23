using System.Text;

public static class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Modo Editor");
        Console.WriteLine("------------");
        Start();
    }

    public static void Start()
    {
        var arquivo = new StringBuilder();

        do
        {
            arquivo.Append(Console.ReadLine());
            arquivo.Append(Environment.NewLine);
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Console.WriteLine("------------");
        Console.WriteLine(" Deseja salvar o arquivo?");

        Viewer.Show(arquivo.ToString());
    }
}