using System;
using System.Collections.Generic;
using MDB.Infrastructure.Mappers;
using MDB.Mappers.Mappers;

namespace Factory.Factories
{
    public class MapperFactory
    {
        private readonly IDictionary<Type, object> _mappers = new Dictionary<Type, object>()
        {
            {typeof(IFilmMapper), new FilmMapper()}
        };


        public object Get(Type mapperType)
        {
            if (_mappers.ContainsKey(mapperType))
            {
                return _mappers[mapperType];
            }
            return null;
        }
    }
}