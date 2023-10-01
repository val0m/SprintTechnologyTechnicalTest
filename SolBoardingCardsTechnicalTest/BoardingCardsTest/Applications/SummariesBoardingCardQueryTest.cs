using BoardingCards.Applications;
using BoardingCards.Applications.Queries;
using BoardingCards.Applications.Request;
using BoardingCards.Contracts;
using BoardingCards.DomainShared.Enums;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace BoardingCardsTest.Applications
{
    public class SummariesBoardingCardQueryTest
    {
        private readonly SummariesBoardingCardsQuery.Handler _sut;

        public SummariesBoardingCardQueryTest()
        {
            // TODO Implement resolve IBoardingCardService with autofac
            _sut = new(
                new BoardingCardService(),
                new Mock<ILogger<SummariesBoardingCardsQuery.Handler>>().Object
            );
        }

        private readonly List<BoardingCardRequest> boardingCardInputsCorrect = new()
        {
            new() { Type = TransportType.AirportBus, Departure = "Barcelona" , Destination = "Gerona Airport" },
            new() { Type = TransportType.Airplane, Departure = "Gerona Airport" , Destination = "Stockholm", SeatNumber = "3A", GateNumber = "45B", TransportNumber = "SK455", BaggageTicketCounter = "344" },
            new() { Type = TransportType.Train, Departure = "Madrid" , Destination = "Barcelona", TransportNumber = "78A", SeatNumber = "45B" },
            new() { Type = TransportType.Airplane, Departure = "Stockholm" , Destination = "New York JFK", SeatNumber = "7B", GateNumber = "22", TransportNumber = "SK22" },
        };

        [Fact]
        public async void Should_GetSummaries_WhenInputIsCorrect()
        {
            // Arrange
            SummariesBoardingCardsQuery.Request request = new(boardingCardInputsCorrect);

            // Act
            List<string> result = await _sut.Handle(request, cancellationToken: default);

            // Assert
            result.Count().Should().Be(5);
            result[0].Should().Be("Take train 78A from Madrid to Barcelona. Sit in seat 45B.");
            result[1].Should().Be("Take the airport bus from Barcelona to Gerona Airport. No seat assignment.");
            result[2].Should().Be("From Gerona Airport, take flight SK455 to Stockholm. Gate 45B, seat 3A. Baggage drop at ticket counter 344.");
            result[3].Should().Be("From Stockholm, take flight SK22 to New York JFK. Gate 22, seat 7B. Baggage will be automatically transferred from your last leg.");
            result[4].Should().Be("You have arrived at your final destination.");
        }
    }
}
