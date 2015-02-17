using System.Collections.Generic;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Operations;
using MDB.Repositories.Repositories;

namespace MDB.Operations.Operation
{
    public class FilmOperation : IFilmOperation
    {
        public IReadOnlyCollection<IFilm> GetCollection()
        {
            throw new System.NotImplementedException();
        }

        public IFilm GetFilm(string name, string genre, int? year)
        {
            var repository = new FilmRepository();
            repository.GetFilm(name, genre, year);

            return null;
        }
    }
}