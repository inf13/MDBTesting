using System;

namespace MDB.Infrastructure.Entities
{
    public interface IFilmActor
    {
        Guid FilmId { get; set; }

        Guid ActorId { get; set; }
    }
}