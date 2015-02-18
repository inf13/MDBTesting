using System;
using System.Collections.Generic;

namespace MDB.Infrastructure.Entities
{
    public interface IFilm : IBaseEntity
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Genre { get; set; }

        int Year { get; set; }

        float Rating { get; set; }

        IList<IDirector> Directors { get; set; }

        IList<IActor> Actors { get; set; }
    }
}