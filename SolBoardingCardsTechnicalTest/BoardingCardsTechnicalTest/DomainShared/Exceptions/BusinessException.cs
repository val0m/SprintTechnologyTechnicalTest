namespace BoardingCards.DomainShared.Exceptions
{
    [Serializable]
    public abstract class BusinessException : Exception
    {
        public virtual int StatusCode => StatusCodes.Status500InternalServerError;

        protected BusinessException() : base()
        {
        }

        protected BusinessException(string? message) : base(message)
        {
        }

        protected BusinessException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
