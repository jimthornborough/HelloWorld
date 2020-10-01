using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.MessageWriter
{
    interface IMessageWriter
    {
        public void WriteText(string messageText)
        {
            Console.WriteLine(messageText);
        }
    }
}
