using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MDB.CommandLineOperations.Operations
{
    public class FilmCommandOperation
    {
         private IDictionary<string,string> film = new ConcurrentDictionary<string, string>();
    }
}