using BoardingCards.Applications.Queries;
using BoardingCards.Contracts;
using BoardingCards.Domain;
using BoardingCards.DomainShared.Exceptions.BoardingCard;
using MediatR;

namespace BoardingCards.Applications.Request
{
    public static class SummariesBoardingCardsQuery
    {
        public record Request(List<BoardingCardRequest> BoardingCardRequest) : IRequest<List<string>>;

        public class Handler : IRequestHandler<Request, List<string>>
        {
            private readonly ILogger<Handler> _logger;
            private readonly IBoardingCardService _boardingCardService;

            private const string FinalDestination = "You have arrived at your final destination.";

            public Handler(IBoardingCardService boardingCardService, ILogger<Handler> logger)
            {
                _boardingCardService = boardingCardService;
                _logger = logger;
            }

            public Task<List<string>> Handle(Request request, CancellationToken cancellationToken)
            {
                List<string> result = new();

                if (request.BoardingCardRequest?.Any() != true)
                {
                    _logger.LogInformation("No boarding cards in the request.");

                    return Task.FromResult(result);
                }

                List<BaseBoardingCard> boardingCardsInput = request.BoardingCardRequest.ConvertAll(_boardingCardService.GetBoardingCardFactory);

                BaseBoardingCard firstBoardingCard = DetermineFirstBoardingCard(boardingCardsInput);

                List<BaseBoardingCard> boardingCardsSorted = ComputeSortingBoardingCards(boardingCardsInput, firstBoardingCard);

                result.AddRange(boardingCardsSorted.ConvertAll(x => x.GetSummary()));

                result.Add(FinalDestination);

                return Task.FromResult(result);
            }

            private static BaseBoardingCard DetermineFirstBoardingCard(IReadOnlyList<BaseBoardingCard> boardingCards) =>
                boardingCards.FirstOrDefault(x => !boardingCards.Any(y => x.Departure.Equals(y.Destination, StringComparison.InvariantCultureIgnoreCase)))
                    ?? throw new BoardingCardsOrderException("It is not possible to determine the first item on boarding cards.");

            private static List<BaseBoardingCard> ComputeSortingBoardingCards(List<BaseBoardingCard> boardingCards, BaseBoardingCard firstBoardingCard)
            {
                List<BaseBoardingCard> boardingCardsSorted = new() { firstBoardingCard };

                string nextDestination = firstBoardingCard.Destination;

                for (int i = 0; i < boardingCards.Count - 1; i++)
                {
                    BaseBoardingCard? nextBoardingCard = boardingCards.SingleOrDefault(x => x.Departure.Equals(nextDestination, StringComparison.InvariantCultureIgnoreCase))
                        ?? throw new BoardingCardsOrderException($"It is not possible to determine the next item on boarding cards with that destination : {nextDestination}");

                    boardingCardsSorted.Add(nextBoardingCard);

                    nextDestination = nextBoardingCard.Destination;
                }

                return boardingCardsSorted;
            }
        }
    }
}
