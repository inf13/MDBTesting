using System;
using MDB.Infrastructure.Operations;
using MDB.WebForms.Base;
using Microsoft.Practices.Unity;

namespace MDB.WebForms
{
    public partial class AddFilm : BasePage
    {
        private IFilmOperation _filmOperation;

        protected void Page_Init(object sender, EventArgs e)
        {
            _filmOperation = Container.Resolve<IFilmOperation>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void ButtonAddFilmClick(object sender, EventArgs e)
        {
            var title = TextBoxFilmTitle.Text;
            var genre = TextBoxFilmGenre.Text;
            var year = int.Parse(TextBoxFilmYear.Text);

            _filmOperation.CreateFilm(title, genre, year);
        }
    }
}