using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public abstract class Validator
    {
        protected readonly Phone Phone;
        
        protected Validator(Phone phone)
        {
            this.Phone = phone;
        }

        public abstract PhoneReport Answer();
    }
}