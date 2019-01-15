namespace FakeSender.Api.Controllers.Responses
{
    public class Phone
    {
        private string _number;
        
        public Phone(string source)
        {
            _number = source;
        }

        public override string ToString()
        {
            return _number;
        }
    }
}