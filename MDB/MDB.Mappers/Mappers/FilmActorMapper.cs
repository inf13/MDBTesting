using System;
using System.Data;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class FilmActorMapper : IFilmActorMapper
    {
        public void Map(IDataReader reader, IFilmActor filmActor)
        {
            filmActor.FilmId = Guid.Parse(reader["FilmId"].ToString());
            filmActor.ActorId = Guid.Parse(reader["ActorId"].ToString());
        }
    }
}