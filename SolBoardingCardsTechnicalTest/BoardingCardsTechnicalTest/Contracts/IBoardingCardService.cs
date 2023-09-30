namespace BoardingCards.Contracts
{
    public interface IBoardingCardService
    {
        public List<string> GetSummaries(List<BoardingCardInput> boardingCardInputs);
    }
}
