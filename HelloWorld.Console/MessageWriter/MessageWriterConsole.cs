using System;

namespace HelloWorld.MessageWriter
{
    class MessageWriterConsole: IMessageWriter
    {
        public void WriteText(string messageText)
        {
            Console.WriteLine(messageText);
            Console.ReadLine();
        }
    }
}
