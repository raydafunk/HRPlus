namespace HRPlus.Application.Expections
{
    public class BadRequest : Exception
    {
        public BadRequest(string massage) : base(massage)
        {

        }
    }
}

