using Microsoft.Extensions.Configuration;

namespace ServiceOrdersManagement.Tests
{
    public static class TestConfiguration
    {
        public static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
