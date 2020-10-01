using HelloWorld.Common;
using System;
using System.Configuration;
using System.Net.Http;

namespace HelloWorld.MessageReader
{
    class MessageReaderApi
    {
        public static string ReadText()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ApiServer"));

                var responseTask = client.GetAsync("helloworld");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<HelloWorldDTO>();
                    readTask.Wait();

                    return readTask.Result.MessageText;
                }
            }

            return "No Message Found";
        }
    }
}
