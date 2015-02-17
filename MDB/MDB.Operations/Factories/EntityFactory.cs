using System;
using MDB.Infrastructure.Factories;
using MDB.Infrastructure.Operations;

namespace MDB.Operations.Factories
{
    public class EntityFactory : IEntityFactory
    {
        public IEntityOperation Get(string parameter)
        {
            throw new Exception("//");
        } 
    }
}