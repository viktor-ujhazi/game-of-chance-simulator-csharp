 /* 
    - ConsoleLogger implements the ILogger interface and both the interface's virtual methods.
    - ConsoleLogger contains the constructor: ConsoleLogger(). Note: there shouldn't be other 
        constructor declared on this class.
    - ConsoleLogger contains a public method (declared by ILogger) that logs blue informational messages 
        to the console: void Info(string). Note: the message format should be INFO 2020-03-09T05:19:03: an informational message.
    - ConsoleLogger contains a public method (declared by ILogger) that logs red informational messages 
        to the console: void Error(string). Note: the message format should be ERROR 2020-03-09T05:19:03: an error message.  
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR ");
            Console.ResetColor();
            Console.Write(DateTime.Now +":");
            
            Console.Write( message);
            Console.WriteLine();
        }

        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("INFO ");
            Console.ResetColor();
            Console.Write(DateTime.Now + ":");

            Console.Write(message);
            Console.WriteLine();
        }

        public ConsoleLogger() 
        {
        }
    }
}
