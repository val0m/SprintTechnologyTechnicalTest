using BoardingCards.Applications.Queries;
using BoardingCards.Contracts;
using BoardingCards.Domain;
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

                List<BaseBoardingCard> boardingCards = request.BoardingCardRequest.ConvertAll(_boardingCardService.GetBoardingCardFactory);
                
                // TODO Call service for sort the boarding cards

                result.Add(FinalDestination);

                return Task.FromResult(result);
            }
        }
    }
}
