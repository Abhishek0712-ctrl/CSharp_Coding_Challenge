using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace UtilPackage
{
    public static class DbConnUtil
    {

        private static IConfigurationRoot _configuration;
        static string s = null;
        static DbConnUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\abhis\\OneDrive\\Desktop\\Foundation Technical Training\\Coding_Challenge\\UtilPackage\\appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        public static string GetConnection(string key)
        {
            s = _configuration.GetConnectionString("PetPalscnstring");
            return s;
        }
    }
}
