using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.MessageWriter
{
    class MessageWriterFactory
    {
        public static IMessageWriter GetWriter(string writerType)
        {
            switch(writerType)
            {
                case ("1"): return new MessageWriterConsole();
                case ("2"): return new MessageWriterDB();
                default:
                    throw new ApplicationException(string.Format("MessageWriter '{0}' cannot be created", writerType));
            }
        }
    }
}
