using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MDB.Entity.Entities;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class FilmDirectorMapper : IFilmDirectorMapper
    {
        public IFilmDirector Map(IDataReader reader)
        {
            var filmDirector = new FilmDirector
            {
                FilmId = Guid.Parse(reader["FilmId"].ToString()),
                DirectorId = Guid.Parse(reader["DirectorId"].ToString())
            };
            return filmDirector;
        }

        public void MapDirectorToFilm(IFilmDirector filmDirector, IList<IFilm> filmList, IList<IDirector> directorList)
        {
            var concreteDirector = directorList.FirstOrDefault(x => x.Id == filmDirector.DirectorId);
            var concreteFilm = filmList.FirstOrDefault(x => x.Id == filmDirector.FilmId);
            if (concreteDirector != null && concreteFilm != null)
            {
                concreteFilm.Directors.Add(concreteDirector);
            }

        }
    }
}