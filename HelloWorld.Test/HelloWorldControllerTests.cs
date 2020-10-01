using HelloWorld.Api;
using HelloWorld.Common;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorld.Test
{
    public class HelloWorldControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private HttpClient _client { get; }

        public HelloWorldControllerTests(WebApplicationFactory<Api.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Message()
        {
            var response = await _client.GetAsync("/helloworld");

            bool isValidResponse = response.StatusCode.Equals(HttpStatusCode.OK);

            Assert.True(isValidResponse, $"The http status code {response.StatusCode} is not valid");

            var stringResponse = await response.Content.ReadAsStringAsync();

            var messageDTO = System.Text.Json.JsonSerializer.Deserialize<HelloWorldDTO>(stringResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            const string helloWorldMessage = "Hello World";

            bool isValidMessage = messageDTO.MessageText.Equals(helloWorldMessage);

            Assert.True(isValidMessage, $"The message {messageDTO.MessageText} is not valid");

            const int helloWorldId = 0;

            var isValidId = messageDTO.Id == helloWorldId;

            Assert.True(isValidId, $"The message Id {messageDTO.Id} is not valid");
        }

        [Fact]
        public async Task Add_Save_With_Response_Ok()
        {
            var response = await _client.PostAsync("/helloworld"
                , new StringContent(
                JsonConvert.SerializeObject(new HelloWorldDTO
                {
                    Id = 0,
                    MessageText = "Hello World"
                }),
            Encoding.UTF8,
            "application/json"));

            response.EnsureSuccessStatusCode();

            var isStatusOk = response.StatusCode.Equals(HttpStatusCode.OK);

            Assert.True(isStatusOk, $"The status code {response.StatusCode} is not valid");
        }
    }
}
