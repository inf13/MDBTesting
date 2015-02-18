using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;
using MDB.Infrastructure.Repositories;
using MDB.Repositories.Constants.StoreProcedure;
using MDB.Repositories.Extensions;
using MDB.Repositories.Heplers;

namespace MDB.Repositories.Repositories
{
    public class FilmRepository : BaseRepository, IFilmRepository
    {
        public IReadOnlyCollection<IFilm> GetCollection()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Get Film Collection
        /// </summary>
        /// <param name="title">Film Title (Optional parameter)</param>
        /// <param name="genre">Filme Genre (Optional parameter)</param>
        /// <param name="year">Film Year (Optional parameter)</param>
        /// <returns>Collection of Films</returns>
        public IList<IFilm> GetFilm(string title, string genre, int? year)
        {
            var filmCollection = new List<IFilm>();

            using (SqlConnection connection = new SqlConnection(ConfigurationHelper.ConnectionString))
            {
                var command = new SqlCommand(FilmConstants.GetFilms, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                //Using Command Extension to add parameters to SQLCommand by parameter's name and values
                command.AddParameter(FilmConstants.FilmTitleParameter, title);
                command.AddParameter(FilmConstants.FilmGenreParameter, genre);
                command.AddParameter(FilmConstants.FilmYearParameter, year);

                command.Connection.Open();

                var reader = command.ExecuteReader();
                var film = (IFilm)base.EntityFactory.Get(typeof(IFilm));

                //Get film collection
                while (reader.Read())
                {
                    //Create film object
                    
                    var filmMapper = (IFilmMapper) base.MapperFactory.Get(typeof (IFilmMapper));

                    // Map data from Reader to Film Entity
                    filmMapper.Map(reader, film);
                    filmCollection.Add(film);
                }
                reader.NextResult();

                // Get directors collection
                while (reader.Read())
                {
                    var director = (IDirector) base.EntityFactory.Get(typeof (IDirector));
                    var directorMapper = (IDirectorMapper) base.MapperFactory.Get(typeof (IDirectorMapper));

                    //Map data from Reader to Director Entity
                    directorMapper.Map(reader, director);

                    film.Directors.Add(director);
                }

                reader.NextResult();

                //Get actor collection
                while (reader.Read())
                {
                    //Get actor object
                    var actor = (IActor) base.EntityFactory.Get(typeof (IActor));
                    var actorMapper = (IActorMapper) base.MapperFactory.Get(typeof (IActorMapper));

                    //Map data from Reader to Actor Entity
                    actorMapper.Map(reader, actor);
                    film.Actors.Add(actor);
                }

                reader.Close();

                //Add film
            }
            return filmCollection;
        }
    }
}