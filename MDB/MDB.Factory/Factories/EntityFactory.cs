using System;
using System.Collections.Generic;
using MDB.Entity.Entities;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Factories;

namespace MDB.Factory.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IDictionary<Type, object> _entity = new Dictionary<Type, object>()
        {
            {typeof(IFilm), new Film()},
            {typeof(IDirector), new Director()},
            {typeof(IActor), new Actor()},
            {typeof(IFilmDirector), new FilmDirector()},
            {typeof(IFilmActor), new FilmActor()}
            
        };


        public object Get(Type entityType)
        {
            if (_entity.ContainsKey(entityType))
            {
                return _entity[entityType];
            }
            throw new Exception(string.Format("EntityFactory dosen't contain constructor for type : {0}", entityType));
        } 
    }
}