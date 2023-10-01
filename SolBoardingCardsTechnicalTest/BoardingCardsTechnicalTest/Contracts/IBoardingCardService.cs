using BoardingCards.Applications.Queries;
using BoardingCards.Domain;

namespace BoardingCards.Contracts
{
    public interface IBoardingCardService
    {
        public BaseBoardingCard GetBoardingCardFactory(BoardingCardRequest input);
    }
}
