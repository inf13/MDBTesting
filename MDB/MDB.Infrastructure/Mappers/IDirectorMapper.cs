using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IDirectorMapper
    {
        IDirector Map(IDataReader reader);
    }
}