using System.Collections.Generic;
using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IFilmDirectorMapper
    {
        IFilmDirector Map(IDataReader reader);

        void MapDirectorToFilm(IFilmDirector filmDirector, IList<IFilm> filmList, IList<IDirector> directorList);
    }
}