using System;
using System.Text.RegularExpressions;
using MDB.Console.CommandLineManagement;
using MDB.Infrastructure.Operations;
using MDB.Unity;
using Microsoft.Practices.Unity;

namespace MDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var unityAutoregistration = new Bootstrapper();
            //var container =  unityAutoregistration.Configure(new UnityContainer());

            //var filmOperation = container.Resolve<IFilmOperation>();

            //var list = filmOperation.GetFilm(null, "Drama", null);

            //Console.WriteLine("Get.GetFilm : null,Drama,null");

            //var line = Console.ReadLine();
            //var consoleHelper = new CommandLineManager();

            //consoleHelper.Parse(line, container);

            //Get.Film : [name=parameter],[name=parameter]
            // Get.Films : [value=list],[genre=dramma]
        }


        private static void Do()
        {
            var line = Console.ReadLine();

            string comandTemplate = @"(\w+):";

            Match match = Regex.Match(line, comandTemplate, RegexOptions.IgnoreCase);
            
        }
    }
}
