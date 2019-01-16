using System;
using System.Linq;
using FakeSender.Api.Controllers;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace FakeSender.Api.Tests.ControllersTests.SmsRuControllerTests
{
    public class SmsSavingTests : SmsRuTestsFixture
    {
        private readonly SmsRuController _controller;

        public SmsSavingTests()
        {
            this._controller = new SmsRuController(this.Db, this.Logger);
        }

        public override void Dispose()
        {
            this.Db.SmsBox.RemoveRange(this.Db.SmsBox);
            this.Db.SaveChanges();
        }

        [Fact]
        public void PhoneIsMobile_And_BalanceIsPositive_Then_SmsShouldBeSaved()
        {
            // Arrange 
            var phone = new Phone(7, 999, 9999999);
            var message = "Hi";
            var expected = new Sms
            {
                To = phone.ToString(),
                Message = message
            };
            
            // Act
            var result = this._controller.Send(
                Guid.Empty,
                this.WithPositiveBalance.Login, 
                1,
                Uri.EscapeUriString(message),
                phone.ToString()
            );

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected.ToJson(), this.Db.SmsBox.First(s => s.To == phone.ToString()).ToJson());
        }
        
        [Fact]
        public void PhoneIsNotMobile_And_BalanceIsPositive_Then_SmsShouldNotBeSaved()
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
            );

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.False(
                this.Db.SmsBox.Any(s => s.To == phone.ToString()),
                "Sms message should not be saved in SmsBox"
            );
        }
        
        [Theory]
        [InlineData("79999999999")]
        [InlineData("78129999999")]
        public void BalanceIsNegative_Then_SmsShouldNotBeSaved(string phoneSource)
        {
            // Arrange 
            var phone = new Phone(phoneSource);
            var message = "Hi";
            
            // Act
            var result = this._controller.Send(
                Guid.Empty,
                this.WithNegativeBalance.Login, 
                1,
                Uri.EscapeUriString(message),
                phone.ToString()
            );

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.False(
                this.Db.SmsBox.Any(s => s.To == phone.ToString()),
                "Sms message should not be saved in SmsBox"
            );
        }
    }
}