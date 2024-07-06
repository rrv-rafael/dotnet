Console.Clear();

try
{
    Cadastrar("");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.InnerException);
    Console.WriteLine(ex.Message);
    Console.WriteLine("Falha ao cadastrar o texto!");
}
catch (MinhaException ex)
{
    Console.WriteLine(ex.InnerException);
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.QuandoAconteceu);
    Console.WriteLine("Exceção customizada.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.InnerException);
    Console.WriteLine(ex.Message);
    Console.WriteLine("Ops, algo deu errado!");
}
finally
{
    Console.WriteLine("Chegou ao fim!");
}

static void Cadastrar(string texto)
{
    if (string.IsNullOrEmpty(texto))
    {
        throw new MinhaException(DateTime.Now);
    }
}

public class MinhaException : Exception
{
    public MinhaException(DateTime date)
    {
        QuandoAconteceu = date;
    }
    public DateTime QuandoAconteceu { get; set; }
}