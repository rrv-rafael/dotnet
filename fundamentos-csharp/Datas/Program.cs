using System.Globalization;

Console.Clear();

var pt = new CultureInfo("pt-PT");
var br = new CultureInfo("pt-BR");
var us = new CultureInfo("en-US");
var de = new CultureInfo("de-DE");
var atual = CultureInfo.CurrentCulture;

Console.WriteLine(DateTime.Now.ToString("D", atual));