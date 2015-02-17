using MDB.Infrastructure.Operations;

namespace MDB.Infrastructure.Factories
{
    public interface IEntityFactory
    {
        IEntityOperation Get(string parameter);
    }
}