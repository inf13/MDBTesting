using System.Collections.Generic;
using MDB.Infrastructure.Models;
using MDB.Infrastructure.Operations;

namespace MDB.Operations.Operation
{
    public class FilmOperation : IFilmOperation
    {
        public IReadOnlyCollection<IFilmModel> GetCollection()
        {
            throw new System.NotImplementedException();
        }

        public IFilmModel GetFilm(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}