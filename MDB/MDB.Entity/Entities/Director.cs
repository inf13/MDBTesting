using System;
using MDB.Infrastructure.Entities;

namespace MDB.Entity.Entities
{
    public class Director : IDirector
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICountry Country { get; set; }
    }
}