using System;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;
using FakeSender.Api.Models;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public class BalanceValidator : Validator
    {
        private readonly Account _account;
        
        public BalanceValidator(Account account)
        {
            this._account = account;
        }
        
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
            return this._account.Balance > 0;
        }
    }
}