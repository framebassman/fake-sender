using System;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public class BalanceValidator : Validator
    {
        public override PhoneReport Answer()
        {
            if (this.IsBalancePositive())
            {
                return new OkPhoneReport();
            }
            else
            {
                return new BadPhoneReport(201, "Не хватает средств на лицевом счету" );
            }
        }

        private Boolean IsBalancePositive()
        {
            return this.RandomBoolean();
        }

        private Boolean RandomBoolean()
        {
            var gen = new Random();
            int prob = gen.Next(100);
            return prob <= 20;
        }
    }
}