using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IActorMapper : IBaseMapper
    {
        void Map(IDataReader reader, IActor actor);
    }
}