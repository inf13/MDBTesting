using System;
using MDB.Infrastructure.Entities;

namespace MDB.Entity.Entities
{
    public class Actor : IActor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}