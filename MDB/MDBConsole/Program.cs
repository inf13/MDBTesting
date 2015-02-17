using System;
using System.Management.Instrumentation;
using MDB.Operations.Operation;

namespace MDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var operation = new FilmOperation();
            operation.GetFilm("Schindler's List", null, null);


            //var line = Console.ReadLine();
            //const string template = "{0}.{1} {2}";
            //var some = Regex.Match(line, @"(.*)\.(.*)");

            //Get.Film : [name=parameter],[name=parameter]
        }


        private void Do()
        {
              

            
        }
    }
}
