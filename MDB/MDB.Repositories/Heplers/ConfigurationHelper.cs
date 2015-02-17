using System.Configuration;
using MDB.Repositories.Constants;

namespace MDB.Repositories.Heplers
{
    public static class ConfigurationHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionConstants.LocalConnectionString].ConnectionString;
            }
        }
    }
}