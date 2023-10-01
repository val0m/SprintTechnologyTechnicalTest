namespace BoardingCards.DomainShared.Exceptions
{
    [Serializable]
    public class BoardingCardNotSupportedException : BusinessException
    {
        public override int StatusCode => StatusCodes.Status500InternalServerError;

        public BoardingCardNotSupportedException() : base()
        {
        }

        public BoardingCardNotSupportedException(string? message) : base(message)
        {
        }

        public BoardingCardNotSupportedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
