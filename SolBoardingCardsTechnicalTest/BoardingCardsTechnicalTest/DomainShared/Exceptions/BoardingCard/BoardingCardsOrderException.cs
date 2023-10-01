namespace BoardingCards.DomainShared.Exceptions.BoardingCard
{
    [Serializable]
    public class BoardingCardsOrderException : BusinessException
    {
        public override int StatusCode => StatusCodes.Status500InternalServerError;

        public BoardingCardsOrderException() : base()
        {
        }

        public BoardingCardsOrderException(string? message) : base(message)
        {
        }

        public BoardingCardsOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
