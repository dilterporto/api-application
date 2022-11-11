using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public ShowtimesController(IMediator mediator) 
        => _mediator = mediator;

    /// <summary>
    /// Get all showtimes optionally filtering by date and movie title
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ShowtimeResponse[]>> GetAllAsync([FromQuery] ShowtimeQueryFilter filter)
    {
        return Ok(new List<ShowtimeResponse>());
    }
        
    /// <summary>
    /// Get showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> GetByIdAsync([FromRoute] int id)
    {
        return Ok(new List<ShowtimeResponse>());
    }

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
        return NoContent();
    }
        
    /// <summary>
    /// Update a showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> UpdateByIdAsync([FromRoute] int id)
    {
        return Ok(new List<ShowtimeResponse>());
    }
        
    /// <summary>
    /// Update partially showtime by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ShowtimeResponse[]>> PatchByIdAsync([FromRoute] int id)
    {
        return Ok(new List<ShowtimeResponse>());
    }
}