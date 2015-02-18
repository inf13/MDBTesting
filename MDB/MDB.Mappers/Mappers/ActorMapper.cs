using System;
using System.Data;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class ActorMapper : IActorMapper
    {
        public void Map(IDataReader reader, IActor actor)
        {
            actor.Id = Guid.Parse(reader["Id"].ToString());
            actor.Name = reader["Name"].ToString();
            actor.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
        }
    }
}