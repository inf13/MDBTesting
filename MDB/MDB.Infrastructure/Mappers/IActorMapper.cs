﻿using System.Data;
using MDB.Infrastructure.Entities;

namespace MDB.Infrastructure.Mappers
{
    public interface IActorMapper
    {
        IActor Map(IDataReader reader);
    }
}