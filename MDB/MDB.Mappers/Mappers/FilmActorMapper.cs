using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MDB.Entity.Entities;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class FilmActorMapper : IFilmActorMapper
    {
        public IFilmActor Map(IDataReader reader)
        {
            var filmActor = new FilmActor
            {
                FilmId = Guid.Parse(reader["FilmId"].ToString()),
                ActorId = Guid.Parse(reader["ActorId"].ToString())
            };
            return filmActor;
        }

        public void MapActorToFilm(IFilmActor filmActor, IList<IFilm> filmCollection, IList<IActor> actorCollection)
        {
            var concreteFilm = filmCollection.FirstOrDefault(x => x.Id == filmActor.FilmId);
            var concreteActor = actorCollection.FirstOrDefault(x => x.Id == filmActor.ActorId);

            if (concreteFilm != null && concreteActor != null)
            {
                concreteFilm.Actors.Add(concreteActor);
            }
        }
    }
}