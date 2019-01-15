using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public abstract class Validator
    {
        protected Phone Phone;
        
        protected Validator(Phone phone)
        {
            Phone = phone;
        }

        public abstract PhoneReport Answer();
    }
}