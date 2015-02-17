using System;

namespace MDB.Infrastructure.Models
{
    public interface IUserModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        float Rating { get; set; }
    }
}