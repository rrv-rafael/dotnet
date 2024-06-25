using System.Globalization;

Console.Clear();

//Timespan:

var timeSpan = new TimeSpan();
Console.WriteLine(timeSpan);

var timeSpanNanoSegundos = new TimeSpan(1);
Console.WriteLine(timeSpanNanoSegundos);

var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
Console.WriteLine(timeSpanHoraMinutoSegundo);

var timeSpanDiaHoraMinutoSegundo = new TimeSpan(3, 5, 50, 10);
Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

var timeSpanDiaHoraMinutoSegundoMilissegundo = new TimeSpan(15, 12, 55, 8, 100);
Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundo);

Console.WriteLine(timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo);
Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Days);
Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0)));

// Timezone:
// var dateTimeUtc = DateTime.UtcNow;

// Console.WriteLine(DateTime.Now);
// Console.WriteLine(dateTimeUtc);

// Console.WriteLine(dateTimeUtc.ToLocalTime());

// var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
// Console.WriteLine(timezoneAustralia);

// var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, timezoneAustralia);
// Console.WriteLine(horaAustralia);

// var timezones = TimeZoneInfo.GetSystemTimeZones();

// foreach (var timezone in timezones)
// {
//     Console.WriteLine(timezone.Id);
//     Console.WriteLine(timezone);
//     Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, timezone));
//     Console.WriteLine("----------------------");
// }