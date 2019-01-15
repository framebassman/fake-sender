using FakeSender.Api.Controllers.Responses.SmsRu.Reports;

namespace FakeSender.Api.Controllers.Responses.SmsRu.Validators
{
    public class MobilePhoneValidator : Validator
    {
        public MobilePhoneValidator(Phone phone)
            : base(phone)
        {
        }

        public override PhoneReport Answer()
        {
            if (Phone.ToString().StartsWith("79") && Phone.ToString().Length == 11)
            {
                return new OkPhoneReport();
            }

            return new BadPhoneReport(
                "ERROR",
                202,
                "Неправильно указан номер телефона получателя, либо на него нет маршрута"
            );
        }
    }
}