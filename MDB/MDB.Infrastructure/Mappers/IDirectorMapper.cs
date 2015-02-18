using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IDirectorMapper : IBaseMapper
    {
        void Map(IDataReader reader, IDirector director);
    }
}