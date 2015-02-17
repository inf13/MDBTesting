using System;
using System.Data;
using MDB.Entity.Entities;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class FilmMapper : IFilmMapper
    {
        public IFilm Map(IDataReader reader)
        {
            var film = new Film
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Title = reader["Title"].ToString(),
                Genre = reader["Genre"].ToString(),
                Year = int.Parse(reader["FilmYear"].ToString()),
                Rating = float.Parse(reader["Rating"].ToString())
            };
            return film;
        }
    }
}