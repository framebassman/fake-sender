using System;
using FakeSender.Api.Controllers;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Controllers.Responses.SmsRu;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace FakeSender.Api.Tests.ControllersTests.SmsRuControllerTests
{
    public class SmsRuResponsesTests : SmsRuTestsFixture
    {
        private readonly SmsRuController _controller;

        public SmsRuResponsesTests()
        {
            this._controller = new SmsRuController(this.Db, this.Logger);
        }

        //  expected Json:
        //  {
        //      "status": "OK",
        //      "status_code": 200,
        //      "balance": 13661462.5,
        //      "sms": {
        //          "79995379788": {
        //              "status_text": "Не хватает средств на лицевом счету",
        //              "status": "ERROR",
        //              "status_code": 201
        //          }
        //      }
        //  }
        [Fact]
        public void NegativeBalanceResponse()
        {
            // Arrange 
            var phone = new Phone("799999999");
            var message = "Hi";
            
            // Act
            var result = this._controller.Send(
                Guid.Empty,
                this.WithNegativeBalance.Login, 
                1,
                Uri.EscapeUriString(message),
                phone.ToString()
            ) as OkObjectResult;
            
            // Assert
            var expected = new OkFromSmsRu(
                phone,
                new BadPhoneReport(
                    201,
                    "Не хватает средств на лицевом счету"
                ),
                this.WithNegativeBalance
            );
            Assert.IsType<OkObjectResult>(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(expectedJson, actualJson);
        }
    }
}