using System.Text.RegularExpressions;

public static class Viewer
{
    public static void Show(string texto)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Modo Visualização");
        Console.WriteLine("------------");
        Replace(texto);
        Console.WriteLine("------------");
        Console.ReadKey();
        Menu.Show();
    }

    public static void Replace(string texto)
    {
        var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
        var words = texto.Split(' ');

        for (var i = 0; i < words.Length; i++)
        {
            if (strong.IsMatch(words[i]))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(
                    words[i].Substring(
                        words[i].IndexOf('>') + 1,
                        (
                            (words[i].LastIndexOf('<') - 1) -
                            words[i].IndexOf('>')
                        )
                    )
                );
                Console.Write(" ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(words[i]);
                Console.Write(" ");
            }
        }
    }
}