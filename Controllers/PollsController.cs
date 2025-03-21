namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollServices pollServices) : ControllerBase
{
    private readonly IPollServices _pollServices = pollServices;

    [HttpGet("getall")]
    public IActionResult GetAll() 
    {
        return Ok(_pollServices.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get (int id)
    {
        var poll = _pollServices.Get(id);

        return poll is null ? NotFound() : Ok(poll);
    }

    [HttpPost("")]
    public IActionResult Add(Poll request)
    {
        var newPoll = _pollServices.Add(request);

        return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Poll request)
    {
        if (!_pollServices.Update(id, request))
            return NotFound();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_pollServices.Delete(id))
            return NotFound();

        return Ok();
    }
}
