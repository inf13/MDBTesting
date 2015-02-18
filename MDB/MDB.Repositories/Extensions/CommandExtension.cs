using System;
using System.Data.SqlClient;

namespace MDB.Repositories.Extensions
{
    public static class CommandExtension
    {
        public static void AddParameter(this SqlCommand command, string name, object value)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            command.Parameters.Add(new SqlParameter()
            {
                ParameterName = name,
                Value = value
            });

        }
    }
}