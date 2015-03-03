namespace MDB.Repositories.Constants.StoreProcedure
{
    public class FilmConstants
    {
        public const string GetFilms = "sp_GetFilms";
        public const string FilmIdParameter = "@filmId";
        public const string FilmTitleParameter = "@filmTitle";
        public const string FilmGenreParameter = "@filmGenre";
        public const string FilmYearParameter = "@filmYear";

        public const string GetFilmsRatedByUser = "sp_GetFilmsRatedByUser";
        public const string UserNickNameParameter = "@userNickName";

        public const string AddFilm = "sp_AddFilm";

    }
}