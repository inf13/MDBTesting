using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IFilmDirectorMapper
    {
        void Map(IDataReader reader, IFilmDirector filmDirector);
    }
}