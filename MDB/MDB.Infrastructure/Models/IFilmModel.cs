using System;

namespace MDB.Infrastructure.Models
{
    public interface IFilmModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Genre { get; set; }

        int Year { get; set; }

        float Rating { get; set; }

    }
}