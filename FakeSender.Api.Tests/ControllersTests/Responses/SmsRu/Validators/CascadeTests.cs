using System.Collections.Generic;
using FakeSender.Api.Controllers.Responses;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;
using FakeSender.Api.Controllers.Responses.SmsRu.Validators;
using FakeSender.Api.Data;
using FakeSender.Api.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FakeSender.Api.Tests.ControllersTests.Responses.SmsRu.Validators
{
    public class CascadeTests
    {
        private Cascade _cascade;
        
        public CascadeTests()
        {
            var smsRu = new Account()
            {
                Type = "sms",
                Service = "smsru",
                Login = "test",
                Balance = 0
            };
            this._cascade = new Cascade(new List<Validator>
            {
                new BalanceValidator(smsRu),
                new MobilePhoneValidator(new Phone("78123333333"))
            });
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(13)]
        [InlineData(14)]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(17)]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(20)]
        [InlineData(21)]
        [InlineData(22)]
        [InlineData(23)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(26)]
        [InlineData(27)]
        [InlineData(28)]
        [InlineData(29)]
        [InlineData(30)]

        public void CascadeAnswer_ShouldBeBad(int counter)
        {
            Assert.IsType<BadPhoneReport>(this._cascade.Answer());
        }
    }
}