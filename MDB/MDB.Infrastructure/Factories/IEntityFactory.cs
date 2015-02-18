using System;

namespace MDB.Infrastructure.Factories
{
    public interface IEntityFactory
    {
        object Get(Type entityType);
    }
}