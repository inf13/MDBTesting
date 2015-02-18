using System;

namespace MDB.Infrastructure.Entities
{
    public interface IDirector : IBaseEntity
    {
        Guid Id { get; set; }

        string Name { get; set; }

        DateTime DateOfBirth { get; set; }

        ICountry Country { get; set; }
    }
}