using System.Collections.Generic;
using MDB.Infrastructure.Models;

namespace MDB.Infrastructure.Repositories
{
    public interface IFilmRepository
    {
        IReadOnlyCollection<IFilmModel> GetCollection();

        IFilmModel GetFilm(string title);
    }
}