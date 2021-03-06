﻿using System;
using System.Collections.Generic;
using MDB.Infrastructure.Entities;

namespace MDB.Entity.Entities
{
    public class Film : IFilm
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }

        public IList<IDirector> Directors { get; set; }

        public IList<IActor> Actors { get; set;  }
    }
}