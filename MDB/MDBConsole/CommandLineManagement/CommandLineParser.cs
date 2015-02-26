using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MDB.Operations.Operation;
using MDBConsole.CommandLineManagement.Constants;

namespace MDBConsole.CommandLineManagement
{
    // Parse input string and invoke actual method.
    //---------------------------------------------------
    // Input value must comply with the following format : OperationName.MethodName  {: param1, param2,...,paramN}
    // OperationName - it's a name of Operation, which must be used for handle following command
    // MethodName - it's a name of Method, which must be invoked
    // {: param1, param2,...,paramN} - optional section. Different method's have undefined parameters count
    public class CommandLineParser
    {
        /// <summary>
        /// Dictionary of compliance. Operation Code to Actual Operation Object
        /// </summary>
        private readonly IDictionary<string, object> _operations = new Dictionary<string, object>()
        {
        //    {"Film", new FilmOperation()}
        };

        /// <summary>
        /// Parse input value and invoke actual method 
        /// </summary>
        /// <param name="inputValue">User command</param>
        public void Parse(string inputValue)
        {
            var commandLine = inputValue.Split(':');

            string methodName;
            string operationCode;

            ParseSignature(commandLine, out methodName, out operationCode);
            
            if (_operations.ContainsKey(operationCode))
            {
                var operation = _operations[operationCode];

                var method = GetMethod(operation, methodName);
                var parameters = GetParametersForInvoke(method, commandLine);

                method.Invoke(operation, parameters);
            }
        }

        /// <summary>
        /// Get method, which handle user command
        /// </summary>
        /// <param name="operation">Operation object, which contains actual method</param>
        /// <param name="methodName">Method name, which handle user command </param>
        /// <returns>Method Info object</returns>
        private MethodInfo GetMethod(Object operation, string methodName)
        {
            var operationType = operation.GetType();

            var method = operationType.GetMethod(methodName);
            return method;
        }

        /// <summary>
        /// Get parameters form input command string.
        /// </summary>
        /// <param name="method">Actual method. Used for verification of compliance actual method parameters with user parameters</param>
        /// <param name="commandLine">User input data splitted by ':'</param>
        /// <returns></returns>
        private object[] GetParametersForInvoke(MethodInfo method, string[] commandLine)
        {
            var userParameters = new List<string>();
            if (commandLine.Length >= 2)
            {
                var parametersLine = commandLine[1];
                userParameters = parametersLine.Split(',').ToList();
            }

            //Get actual method's parameters
            var parameters = method.GetParameters();

            object[] objects = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                //If user parameter list contains parameter number i
                if (userParameters.Count > i)
                {
                    //If user enter 'null' as parameter value
                    var userParameter = userParameters[i].Trim();
                    if (userParameter.Equals(CommandLineParsingConstants.NullValue) || string.IsNullOrEmpty(userParameter))
                    {
                        //then - set value of this parameter at null
                        objects[i] = null;
                    }

                    //then - add this parameter to actual object list
                    objects[i] = userParameter;
                }
                else
                {
                    //else - set value of this parameter at null
                    objects[i] = null;
                }
            }
            return objects;
        }

        /// <summary>
        /// Get Method Name and Operation Code form user input data 
        /// </summary>
        /// <param name="commandLine">User input data splitted by ':'</param>
        /// <param name="methodName">Get actual method name from user input data</param> 
        /// <param name="operationCode">Get Operation Code from user input data (For ex: FilmOperation - code would be Film) </param>
        private void ParseSignature(string[] commandLine, out string methodName, out string operationCode)
        {

            var command = commandLine[0];

            //Split user data by '.'
            var signature = command.Split('.');
            if (signature.Length >= 2)
            {
                //First segmemt - operation code
                operationCode = signature[0].Trim();
                //Second segmemt - method name
                methodName = signature[1].Trim();
                return;
            }

            throw new Exception("Wrong data input format");
        }
    }
}