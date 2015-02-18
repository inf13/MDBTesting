using System;

namespace MDB.Infrastructure.Factories
{
    public interface IMapperFactory
    {
        object Get(Type mapperType);
    }
}