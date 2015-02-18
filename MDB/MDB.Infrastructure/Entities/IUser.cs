using System;

namespace MDB.Infrastructure.Entities
{
    public interface IUser : IBaseEntity
    {
        Guid Id { get; set; }

        string Name { get; set; }

        float Rating { get; set; }
    }
}