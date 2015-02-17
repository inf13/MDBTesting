using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Transactions;
using Factory.Factories;
using MDB.Infrastructure.Entities;
using MDB.Infrastructure.Mappers;
using MDB.Infrastructure.Repositories;
using MDB.Mappers.Mappers;
using MDB.Repositories.Constants;
using MDB.Repositories.Heplers;

namespace MDB.Repositories.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        public IReadOnlyCollection<IFilm> GetCollection()
        {
            throw new System.NotImplementedException();
        }

        public IFilm GetFilm(string title, string genre, int? year)
        {
            var list = new List<string>();
            var mapperFactory = new MapperFactory();
            using (var transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationHelper.ConnectionString))
                {
                    var command = new SqlCommand(StoreProcedureConstants.GetFilms, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@filmTitle",
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        Value = title
                    });

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@filmGenre",
                        DbType = DbType.String,
                        Direction = ParameterDirection.Input,
                        Value = genre
                    });

                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@filmYear",
                        DbType = DbType.Int32,
                        Direction = ParameterDirection.Input,
                        Value = year
                    });

                    
                    command.Connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var filmMapper = (IFilmMapper)mapperFactory.Get(typeof(IFilmMapper));
                        var film = filmMapper.Map(reader);
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        list.Add(reader["Name"].ToString());
                    }

                    reader.NextResult();

                    while (reader.Read())
                    {
                        list.Add(reader["Name"].ToString());
                    }

                    reader.Close();


                }
                transactionScope.Complete();
            }
            return null;
        }
    }
}