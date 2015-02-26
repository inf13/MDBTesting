using System.Collections.Generic;
using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IFilmActorMapper
    {
        IFilmActor Map(IDataReader reader);

        void MapActorToFilm(IFilmActor filmActor, IList<IFilm> filmCollection, IList<IActor> actorCollection);
    }
}