using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public abstract class Validator
    {
        public abstract PhoneReport Answer();
    }
}