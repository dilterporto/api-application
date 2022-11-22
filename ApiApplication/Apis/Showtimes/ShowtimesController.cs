using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using ApiApplication.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Apis.Showtimes;

/// <summary>
/// Manage showtime resource
/// </summary>
[Route("v1/showtimes")]
[ApiController]
[Produces("application/json")]
public class ShowtimesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IShowtimesRepository _showtimesRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="showtimesRepository"></param>
    public ShowtimesController(IMediator mediator, IShowtimesRepository showtimesRepository)
    {
        _mediator = mediator;
        _showtimesRepository = showtimesRepository;
    }

    /// <summary>
    /// Get all showtimes optionally filtering by date and movie title
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ShowtimeResponse[]>> GetAllAsync([FromQuery] ShowtimeQueryFilter filter)
        => Ok(await _mediator.Send(new GetShowtimesByFilterQueryRequest(filter)));

    /// <summary>
    /// Get showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> GetByIdAsync([FromRoute] int id) 
        => Ok(await _mediator.Send(new GetShowtimeByIdQueryRequest(id)));

    /// <summary>
    /// Create a new showtime
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<ShowtimeResponse>> PostAsync([FromBody] CreateShowtimeRequest request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = response.Id }, response);
    }
        
    /// <summary>
    /// Delete a showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> DeleteByIdAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteShowtimeByIdRequest(id));
        return NoContent();
    }
        
    /// <summary>
    /// Update a showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> UpdateByIdAsync([FromRoute] int id, [FromBody] ChangeShowtimeByIdRequest request)
    {
        var updatedShowtime = await _mediator.Send(request);
        return Ok(updatedShowtime);
    }
        
    /// <summary>
    /// Update partially showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> PatchByIdAsync([FromRoute] int id) 
        => throw new Exception("throws an error for testing error handling");
}