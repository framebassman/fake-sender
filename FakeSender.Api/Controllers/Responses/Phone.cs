using System.Text;

namespace FakeSender.Api.Controllers.Responses
{
    public class Phone
    {
        private readonly string _number;
        
        public Phone(string source)
        {
            this._number = source;
        }

        public Phone(int region, int code, int number)
        {
            this._number = new StringBuilder()
                .Append(region)
                .Append(code)
                .Append(number)
                .ToString();
        }

        public override string ToString()
        {
            return this._number;
        }
    }
}