using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IFilmActorMapper
    {
        void Map(IDataReader reader, IFilmActor filmActor);
    }
}