using HelloWorld.Common;
using System;
using System.Configuration;
using System.Net.Http;

namespace HelloWorld.MessageWriter
{
    class MessageWriterDB : IMessageWriter
    {
        public void WriteText(string messageText)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiServer"));

                var messageDTO = new HelloWorldDTO() { MessageText = messageText };

                var postTask = client.PostAsJsonAsync<HelloWorldDTO>("helloworld", messageDTO);
                postTask.Wait();

                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HelloWorldDTO>();

                    readTask.Wait();

                    var insertedMessage = readTask.Result;

                    Console.WriteLine("Message {0} inserted with id: {1}", insertedMessage.MessageText, insertedMessage.Id);
                }
                else
                {
                    Console.WriteLine(result.StatusCode);
                }
            }
        }
    }
}
