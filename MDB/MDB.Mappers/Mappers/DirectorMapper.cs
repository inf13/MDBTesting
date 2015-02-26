using System;
using System.Data;
using MDB.Entity.Entities;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;

namespace MDB.Mappers.Mappers
{
    public class DirectorMapper : IDirectorMapper
    {
        public IDirector Map(IDataReader reader)
        {
            var director = new Director
            {
                Id = Guid.Parse(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString())
            };
            return director;
        }
    }
}