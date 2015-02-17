using System;
using System.Collections.Generic;

namespace MDB.Infrastructure.Entities
{
    public interface IFilm
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Genre { get; set; }

        int Year { get; set; }

        float Rating { get; set; }

        IReadOnlyCollection<IDirector> Directors { get; set; }

        IReadOnlyCollection<IActor> Actors { get; set; }
    }
}