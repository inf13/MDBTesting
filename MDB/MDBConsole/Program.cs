using System;
using System.Text.RegularExpressions;
using MDB.Operations.Operation;
using MDBConsole.CommandLineManagement;

namespace MDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = new FilmOperation();
            var list = operation.GetFilm(null, "Drama", null);

            //Console.WriteLine("Get.GetFilm : null,Drama,null");


            //var line = Console.ReadLine();
            //var consoleHelper = new CommandLineParser();

            //consoleHelper.Parse(line);

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
