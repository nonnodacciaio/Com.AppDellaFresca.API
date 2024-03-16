namespace Com.AppDellaFresca.API;

public class Config
{
    public Config(AppSettings appSettings)
    {
        Settings = appSettings;
    }

    public static AppSettings Settings { get; private set; }
}
