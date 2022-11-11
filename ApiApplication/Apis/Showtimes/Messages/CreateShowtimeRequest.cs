using System;
using System.Collections.Generic;
using System.ComponentModel;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Messages;

/// <summary>
/// 
/// </summary>
public class CreateShowtimeRequest : IRequest<ShowtimeResponse>
{
    /// <summary>
    /// 
    /// </summary>
    public DateTime StartDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime EndDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    
    [DefaultValue(new[]{ "10:00", "11:00" })]
    public IEnumerable<string> Schedule { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public MovieRequest Movie { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int AuditoriumId { get; set; }
}

/// <summary>
/// 
/// </summary>
public class MovieRequest
{
    /// <summary>
    /// 
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue("tt1375666")]
    public string ImdbId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Stars { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime ReleaseDate { get; set; }
}