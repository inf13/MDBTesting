using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class FilmDirectorMapper : IFilmDirectorMapper
    {
        public void Map(IDataReader reader, IFilmDirector filmDirector)
        {
            filmDirector.FilmId = Guid.Parse(reader["FilmId"].ToString());
            filmDirector.DirectorId = Guid.Parse(reader["DirectorId"].ToString());
        }

        public void MapDirectorToFilm(IList<IFilmDirector> filmDirectorList, IList<IFilm> filmList, IList<IDirector> directorList)
        {
            foreach (var filmDirector in filmDirectorList)
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
}