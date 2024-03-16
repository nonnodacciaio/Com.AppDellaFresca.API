using Serilog.Core;
using System.Globalization;

namespace Com.AppDellaFresca.API;

public class AppSettings
{
    public string Log_Level { get; set; } = "debug";
    public LoggingLevelSwitch LogLevelSwitch => new LoggingLevelSwitch(Enum.Parse<Serilog.Events.LogEventLevel>(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.Log_Level)));

    public string? Supported_Cultures { get; set; } = "it-IT";

    public string? MySql_Host { get; set; } = null;
    public string? MySql_DbName { get; set; } = null;
    public string? MySql_User { get; set; } = null;
    public string? MySql_Password { get; set; } = null;

    public string DbConnectionString => $"Server={this.MySql_Host};Database={this.MySql_DbName};User={this.MySql_User};Password={this.MySql_Password};";
}
