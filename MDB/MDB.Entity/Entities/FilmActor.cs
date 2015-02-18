using System;
using MDB.Infrastructure.Entities;

namespace MDB.Entity.Entities
{
    public class FilmActor : IFilmActor
    {
        public Guid FilmId { get; set; }

        public Guid ActorId { get; set; }
    }
}