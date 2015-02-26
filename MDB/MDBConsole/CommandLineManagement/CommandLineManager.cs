using MDB.Infrastructure.Operations;
using Microsoft.Practices.Unity;

namespace MDB.Console.CommandLineManagement
{
    // Parse input string and invoke actual method.
    //---------------------------------------------------
    // Input value must comply with the following format : OperationName.MethodName  {: param1, param2,...,paramN}
    // OperationName - it's a name of Operation, which must be used for handle following command
    // MethodName - it's a name of Method, which must be invoked
    // {: param1, param2,...,paramN} - optional section. Different method's have undefined parameters count
    public class CommandLineManager
    {
        private readonly CommandLineParser _commandLineParser = new CommandLineParser();
        
        /// <summary>
        /// Parse input value and invoke actual method 
        /// </summary>
        /// <param name="inputValue">User command</param>
        /// <param name="container">Unity container</param>
        public void Parse(string inputValue, UnityContainer container)
        {
            var commandLine = inputValue.Split(':');

            string methodName;
            string operationCode;

            _commandLineParser.ParseSignature(commandLine, out methodName, out operationCode);

            object resolvedObject;


            switch (operationCode)
            {
                case "Film":
                {
                    resolvedObject = container.Resolve<IFilmOperation>();
                }
                    break;
                default:
                    return;
            }
            var method = _commandLineParser.GetMethod(resolvedObject, methodName);
            var parameters = _commandLineParser.GetMethodParameters(method, commandLine);

            method.Invoke(resolvedObject, parameters);
        }
        

       
    }
}