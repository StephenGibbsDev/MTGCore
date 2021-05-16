using MTGCore.Configuration.Interfaces;

namespace MTGCore.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        // TODO(CD): Should use env var
        public string BaseUrl => "http://localhost:8080/";
    }
}