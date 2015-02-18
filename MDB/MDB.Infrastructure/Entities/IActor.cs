using System;

namespace MDB.Infrastructure.Entities
{
    public interface IActor : IBaseEntity
    {
        Guid Id { get; set; }

        string Name { get; set; }

        DateTime DateOfBirth { get; set; }    
    }
}