﻿using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IFilmMapper : IBaseMapper
    {
        void Map(IDataReader reader, IFilm film);
    }
}