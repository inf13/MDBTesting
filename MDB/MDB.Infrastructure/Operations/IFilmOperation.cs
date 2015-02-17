using System.Collections.Generic;
using MDB.Infrastructure.Models;

namespace MDB.Infrastructure.Operations
{
    public interface IFilmOperation : IEntityOperation
    {
        IReadOnlyCollection<IFilmModel> GetCollection();

        IFilmModel GetFilm(string name);
    }
}