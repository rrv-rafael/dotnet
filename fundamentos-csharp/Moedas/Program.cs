using System.Globalization;

Console.Clear();

decimal valor = 10536.25m;
Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));