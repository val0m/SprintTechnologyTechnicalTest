using BoardingCards.Contracts;
using MediatR;

namespace BoardingCards.Applications.Request
{
    public static class SummariesBoardingCardsQuery
    {
        public class Request : IRequest<List<string>>
        {
            public List<BoardingCardInput> BoardingCardInputs { get; set; }
        }
        public class Handler : IRequestHandler<Request, List<string>>
        {
            private readonly ILogger<Handler> _logger;
            private readonly IBoardingCardService _boardingCardService;

            public Handler(IBoardingCardService boardingCardService, ILogger<Handler> logger)
            {
                _boardingCardService = boardingCardService;
                _logger = logger;
            }

            public Task<List<string>> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
