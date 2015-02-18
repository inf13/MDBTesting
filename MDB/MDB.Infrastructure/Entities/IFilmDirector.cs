using System;

namespace MDB.Infrastructure.Entities
{
    public interface IFilmDirector
    {
        Guid FilmId { get; set; }

        Guid DirectorId { get; set; } 
    }
}