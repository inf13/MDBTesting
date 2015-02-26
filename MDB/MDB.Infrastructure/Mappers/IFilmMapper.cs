using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IFilmMapper
    {
        IFilm Map(IDataReader reader);
    }
}