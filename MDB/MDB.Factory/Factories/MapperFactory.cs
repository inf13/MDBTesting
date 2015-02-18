using System;
using System.Collections.Generic;
using MDB.Infrastructure.Factories;
using MDB.Infrastructure.Mappers;
using MDB.Mappers.Mappers;

namespace MDB.Factory.Factories
{
    public class MapperFactory : IMapperFactory
    {
        private readonly IDictionary<Type, object> _mappers = new Dictionary<Type, object>()
        {
            {typeof(IFilmMapper), new FilmMapper()},
            {typeof(IDirectorMapper), new DirectorMapper()},
            {typeof(IActorMapper), new ActorMapper()}
        };


        public object Get(Type mapperType)
        {
            if (_mappers.ContainsKey(mapperType))
            {
                return _mappers[mapperType];
            }
            throw new Exception(string.Format("MapperFactory dosen't contain constructor for type : {0}", mapperType));
        }
    }
}