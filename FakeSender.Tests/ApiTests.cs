using System;
using Xunit;
using RestSharp;
using System.Net;

namespace FakeSender.Tests
{
    public class ApiTests
    {
        [Fact]
        public void SmsApi_AfterStartingApplication_ReturnsOK()
        {
            // Arrange
            var client = new RestClient("http://localhost:5050");
            var request = new RestRequest("api/sms", Method.GET);

            // Act
            IRestResponse response = client.Execute(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
