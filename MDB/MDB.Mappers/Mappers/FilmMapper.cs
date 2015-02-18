using System;
using System.Collections.Generic;
using System.Data;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class FilmMapper : IFilmMapper
    {
        public void Map(IDataReader reader, IFilm film)
        {
            film.Id = Guid.Parse(reader["Id"].ToString());
            film.Title = reader["Title"].ToString();
            film.Genre = reader["Genre"].ToString();
            film.Year = int.Parse(reader["FilmYear"].ToString());
            film.Rating = float.Parse(reader["Rating"].ToString());
            film.Directors = new List<IDirector>();
            film.Actors = new List<IActor>();
        }
    }
}