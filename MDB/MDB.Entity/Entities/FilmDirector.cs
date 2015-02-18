using System;
using MDB.Infrastructure.Entities;

namespace MDB.Entity.Entities
{
    public class FilmDirector : IFilmDirector
    {
        public Guid FilmId { get; set; }

        public Guid DirectorId { get; set; }
    }
}