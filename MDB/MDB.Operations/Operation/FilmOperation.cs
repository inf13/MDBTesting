using System.Collections.Generic;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Operations;
using MDB.Infrastructure.Repositories;
using Microsoft.Practices.Unity;

namespace MDB.Operations.Operation
{
    public class FilmOperation : IFilmOperation
    {
        [Dependency]
        protected IFilmRepository FilmRepository { get; set; }

        public IReadOnlyCollection<IFilm> GetCollection()
        {
            throw new System.NotImplementedException();
        }

        public IList<IFilm> GetFilm(string name, string genre, int? year)
        {
            var result = FilmRepository.GetFilm(name, genre, year);
            
            return result;
        }
    }
}