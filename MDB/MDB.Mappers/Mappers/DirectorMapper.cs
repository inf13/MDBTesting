using System;
using System.Data;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class DirectorMapper : IDirectorMapper
    {
        public void Map(IDataReader reader, IDirector director)
        {
            director.Id = Guid.Parse(reader["Id"].ToString());
            director.Name = reader["Name"].ToString();
            director.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
        }
    }
}