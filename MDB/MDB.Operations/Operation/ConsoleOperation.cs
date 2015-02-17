using System.Collections.Generic;
using System.Diagnostics;
using MDB.Infrastructure.Factories;
using MDB.Infrastructure.Operations;
using MDB.Operations.Factories;

namespace MDB.Operations.Operation
{
    public class ConsoleOperation : IConsoleOperation
    {

        public void Process()
        {
            
        }

        

        private void Modify()
        {
            throw new System.NotImplementedException();
        }

        private IReadOnlyCollection<string> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}