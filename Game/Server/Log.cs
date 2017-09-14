using System;
using Common;

namespace Server
{
    class ServerLog : Log
    {
        protected override void WriteHandler(object message, object className)
        {
            if (className != null)
                Console.WriteLine(message + $" @ {className}");
            else
                Console.WriteLine(message);
            Console.Out.Flush();
        }

        protected override void WarningHandler(object message, object className)
        {
            if (className != null)
                Console.WriteLine(message + $" @ {className}");
            else
                Console.WriteLine(message);
            Console.Out.Flush();
        }

        protected override void ErrorHandler(object message, object className)
        {
            if (className != null)
                Console.WriteLine(message + $" @ {className}");
            else
                Console.WriteLine(message);
            Console.Out.Flush();
        }
    }
}
