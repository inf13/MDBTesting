using System.Collections.Generic;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Operations
{
    public interface IFilmOperation : IEntityOperation
    {
        IReadOnlyCollection<IFilm> GetCollection();

        IList<IFilm> GetFilm(string name, string genre, int? year);
    }
}