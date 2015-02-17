using System.Collections.Generic;
using MDB.Infrastructure.Models;
using MDB.Infrastructure.Repositories;

namespace MDB.Repositories.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        public IReadOnlyCollection<IFilmModel> GetCollection()
        {
            throw new System.NotImplementedException();
        }

        public IFilmModel GetFilm(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}