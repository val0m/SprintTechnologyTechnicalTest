using BoardingCards.DomainShared.Enums;

namespace BoardingCards.Domain
{
    public class TrainBoardingCard : BaseBoardingCard
    {
        public TrainBoardingCard(string departure, string destination) : base(TransportType.Train, departure, destination)
        {
        }
    }
}
