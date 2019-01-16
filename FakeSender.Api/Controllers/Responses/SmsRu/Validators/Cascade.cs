using System.Collections.Generic;
using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public class Cascade : Validator
    {
        private readonly IEnumerable<Validator> _validators;

        public Cascade(IEnumerable<Validator> validators)
        {
            this._validators = validators;
        }

        public override PhoneReport Answer()
        {
            foreach (var validator in this._validators)
            {
                if (validator.Answer() is BadPhoneReport)
                {
                    return validator.Answer();
                }
            }

            return new OkPhoneReport();
        }
    }
}