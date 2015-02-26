using System.Collections.Generic;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Repositories
{
    public interface IFilmRepository : IBaseRepository
    {
        IReadOnlyCollection<IFilm> GetCollection();

        IList<IFilm> GetFilm(string title, string genre, int? year);

        IList<IFilm> GetFilmsRatedByUser(string userNickName);
    }
}