using System;
using System.Data;
using MDB.Entity.Entities;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class ActorMapper : IActorMapper
    {
        public IActor Map(IDataReader reader)
        {
            var actor = new Actor
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString())
            };
            return actor;
        }
    }
}