public static class Config
{
    /// <summary>
    /// Name of the environment variable that holds the OpenWeather API key.
    /// </summary>
    public const string API_TOKEN_ENV_VAR = "OPENWEATHER_API_KEY";

    /// <summary>
    /// OpenWeather API key, read from the environment so that no secret is stored in source control.
    /// </summary>
    public static string API_TOKEN =>
        Environment.GetEnvironmentVariable(API_TOKEN_ENV_VAR) ?? string.Empty;
}
