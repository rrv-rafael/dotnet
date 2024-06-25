using System.Globalization;

Console.Clear();

var dateTimeUtc = DateTime.UtcNow;

Console.WriteLine(DateTime.Now);
Console.WriteLine(dateTimeUtc);

Console.WriteLine(dateTimeUtc.ToLocalTime());

var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
Console.WriteLine(timezoneAustralia);

var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, timezoneAustralia);
Console.WriteLine(horaAustralia);

var timezones = TimeZoneInfo.GetSystemTimeZones();

foreach (var timezone in timezones)
{
    Console.WriteLine(timezone.Id);
    Console.WriteLine(timezone);
    Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dateTimeUtc, timezone));
    Console.WriteLine("----------------------");
}