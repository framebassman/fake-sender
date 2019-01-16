using System;
using FakeSender.Api.Controllers;
using FakeSender.Api.Data;
using FakeSender.Api.Models;

namespace FakeSender.Api.Tests.ControllersTests.SmsRuControllerTests
{
    public abstract class SmsRuTestsFixture : ControllerTestsBase<SmsRuController>, IDisposable
    {
        protected readonly Account WithPositiveBalance;
        protected readonly Account WithNegativeBalance;
        protected readonly ApplicationContext Db;
        
        protected SmsRuTestsFixture()
        {
            this.Db = new ApplicationContext(Options);
            this.WithPositiveBalance = new Account
            {
                Service = "smsru",
                Type = "sms",
                Balance = 100,
                Login = "positive"
            };
            this.WithNegativeBalance = new Account
            {
                Service = "smsru",
                Type = "sms",
                Balance = 0,
                Login = "negative"
            };
            this.Db.Accounts.Add(this.WithPositiveBalance);
            this.Db.Accounts.Add(this.WithNegativeBalance);
            this.Db.SaveChanges();
        }
        
        public virtual void Dispose()
        {
            this.Db.Dispose();
        }
    }
}