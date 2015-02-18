using MDB.Factory.Factories;
using MDB.Infrastructure.Factories;

namespace MDB.Repositories.Repositories
{
    public class BaseRepository
    {
        public IMapperFactory MapperFactory
        {
            get { return new MapperFactory(); }
        }

        public IEntityFactory EntityFactory
        {
            get { return new EntityFactory(); }
        }

    }
}