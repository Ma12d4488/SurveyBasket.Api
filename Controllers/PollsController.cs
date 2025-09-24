using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollServices pollServices) : ControllerBase
{
    private readonly IPollServices _pollServices = pollServices;


    [HttpGet("getall")]
    public IActionResult GetAll() 
    {
        var polls = _pollServices.GetAll();
        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);
    }


    [HttpGet("{id}")]
    public IActionResult Get ([FromRoute] int id)
    {
        var poll = _pollServices.Get(id);

        var response = poll.Adapt<PollResponse>();

        return poll is null ? NotFound() : Ok(response);
    }


    [HttpPost("")]
    public IActionResult Add([FromBody] CreatePollRequest request)
    {
        var newPoll = _pollServices.Add(request.Adapt<Poll>());

        return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
    }


    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id,[FromBody] CreatePollRequest request)
    {
        if (!_pollServices.Update(id, request.Adapt<Poll>()))
            return NotFound();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete([FromBody] int id)
    {
        if (!_pollServices.Delete(id))
            return NotFound();

        return Ok();
    }
}
