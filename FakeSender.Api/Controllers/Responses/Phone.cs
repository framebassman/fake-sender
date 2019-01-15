namespace FakeSender.Api.Controllers.Responses
{
    public class Phone
    {
        private readonly string _number;
        
        public Phone(string source)
        {
            this._number = source;
        }

        public override string ToString()
        {
            return this._number;
        }
    }
}