using BoardingCards.Applications.Request;
using BoardingCards.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BoardingCards.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardingCardsController : ControllerBase
    {
        private readonly ILogger<BoardingCardsController> _logger;
        private readonly IMediator _mediator;

        public BoardingCardsController(
            ILogger<BoardingCardsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSummaryBoardingCards")]
        [Route("Summary")]
        public async Task<ActionResult<List<string>>> GetSummariesAsync([FromBody] List<BoardingCardInput> boardingCardInputs)
        {
            try
            {
                SummariesBoardingCardsQuery.Request request = new() { BoardingCardInputs = boardingCardInputs };

                List<string> summaries = await _mediator.Send(request);

                return Ok(summaries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error has been detected on the route {nameof(GetSummariesAsync)}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}