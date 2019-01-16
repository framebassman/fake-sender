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

        public SmsRuResponsesTests() : base("smsru_responses")
        {
            this._controller = new SmsRuController(this.Db, this.Logger);
        }
        
        //  expected json:
        //  {
        //      "status": "OK",
        //      "status_code": 200,
        //      "balance": 100.0,
        //      "sms": {
        //          "79999999999": {
        //              "sms_id": "1111_2222",
        //              "status": "OK",
        //              "status_code": 100
        //          }
        //      }
        //  }
        [Fact]
        public void PositiveBalance_Response()
        {
            // Arrange 
            var phone = new Phone(7, 999, 9999999);
            var message = "Hi";
            
            // Act
            var result = this._controller.Send(
                Guid.Empty,
                this.WithPositiveBalance.Login, 
                1,
                Uri.EscapeUriString(message),
                phone.ToString()
            ) as OkObjectResult;
            
            // Assert
            var expected = new OkFromSmsRu(
                phone,
                new OkPhoneReport(),
                this.WithPositiveBalance
            );
            Assert.IsType<OkObjectResult>(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(expectedJson, actualJson);
        }

        //  expected json:
        //  {
        //      "status": "OK",
        //      "status_code": 200,
        //      "balance": 0.0,
        //      "sms": {
        //          "79995379788": {
        //              "status_text": "Не хватает средств на лицевом счету",
        //              "status": "ERROR",
        //              "status_code": 201
        //          }
        //      }
        //  }
        [Fact]
        public void NegativeBalance_Response()
        {
            // Arrange 
            var phone = new Phone(7, 999, 9999999);
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
        
        //  expected json:
        //  {
        //      "status": "OK",
        //      "status_code": 200,
        //      "balance": 0.0,
        //      "sms": {
        //          "79995379788": {
        //              "status_text": "Неправильно указан номер телефона получателя, либо на него нет маршрута",
        //              "status": "ERROR",
        //              "status_code": 202
        //          }
        //      }
        //  }
        [Fact]
        public void NotMobilePhone_Response()
        {
            // Arrange 
            var phone = new Phone(7, 812, 9999999);
            var message = "Hi";
            
            // Act
            var result = this._controller.Send(
                Guid.Empty,
                this.WithPositiveBalance.Login, 
                1,
                Uri.EscapeUriString(message),
                phone.ToString()
            ) as OkObjectResult;
            
            // Assert
            var expected = new OkFromSmsRu(
                phone,
                new BadPhoneReport(
                    202,
                    "Неправильно указан номер телефона получателя, либо на него нет маршрута"
                ),
                this.WithPositiveBalance
            );
            Assert.IsType<OkObjectResult>(result);
            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(result.Value);
            Assert.Equal(expectedJson, actualJson);
        }
    }
}