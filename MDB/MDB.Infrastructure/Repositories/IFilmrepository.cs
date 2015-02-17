using System.Collections.Generic;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Repositories
{
    public interface IFilmRepository
    {
        IReadOnlyCollection<IFilm> GetCollection();

        IFilm GetFilm(string title, string genre, int? year);
    }
}