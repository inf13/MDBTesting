using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;
using MDB.Infrastructure.Repositories;
using MDB.Repositories.Constants.StoreProcedure;
using MDB.Repositories.Extensions;
using MDB.Repositories.Heplers;
using Microsoft.Practices.Unity;

namespace MDB.Repositories.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        [Dependency]
        protected IFilmMapper FilmMapper { get; set; }

        [Dependency]
        protected IDirectorMapper DirectorMapper { get; set; }

        [Dependency]
        protected IFilmDirectorMapper FilmDirectorMapper { get; set; }

        [Dependency]
        protected IActorMapper ActorMapper { get; set; }

        [Dependency]
        protected IFilmActorMapper FilmActorMapper { get; set; }

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
                

                //Get film collection
                while (reader.Read())
                {
                    // Map data from Reader to Film Entity
                    var film = FilmMapper.Map(reader);
                    filmCollection.Add(film);
                }
                reader.NextResult();

                var directorCollection = new List<IDirector>();

                // Get directors collection
                while (reader.Read())
                {
                    //Map data from Reader to Director Entity
                    var director = DirectorMapper.Map(reader);
                    directorCollection.Add(director);
                }
                
                reader.NextResult();

                //Get director to film relation

                while (reader.Read())
                {
                    var filmDirector = FilmDirectorMapper.Map(reader);
                    FilmDirectorMapper.MapDirectorToFilm(filmDirector, filmCollection, directorCollection);
                }

                reader.NextResult();

                var actorCollection = new List<IActor>();

                //Get actor collection
                while (reader.Read())
                {
                    //Get actor object

                    //Map data from Reader to Actor Entity
                    var actor = ActorMapper.Map(reader);
                    actorCollection.Add(actor);
                }

                reader.NextResult();

                //Get actor to film collection
                while (reader.Read())
                {
                    var filmActor = FilmActorMapper.Map(reader);
                    FilmActorMapper.MapActorToFilm(filmActor, filmCollection, actorCollection);
                }

                reader.Close();

                //Add film
            }
            return filmCollection;
        }


        public IList<IFilm> GetFilmsRatedByUser(string userNickName)
        {
            var filmCollection = new List<IFilm>();

            using (var connection = new SqlConnection(ConfigurationHelper.ConnectionString))
            {
                var command = new SqlCommand(FilmConstants.GetFilmsRatedByUser, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.AddParameter(FilmConstants.UserNickNameParameter, userNickName);

                command.Connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var film = FilmMapper.Map(reader);
                    filmCollection.Add(film);
                }
                reader.Close();
            }
            
            return filmCollection;
        }
    }
}