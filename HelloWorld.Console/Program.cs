using HelloWorld.MessageWriter;
using HelloWorld.MessageReader;
using System.Configuration;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageWriterFactory
                .GetWriter(ConfigurationManager.AppSettings.Get("WriterTypeID"))
                .WriteText(MessageReaderApi.ReadText());
        }
    }
}
