using System;
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
    public string Schedule { get; set; }
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
    public string ImdbId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string Starts { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime ReleaseDate { get; set; }
}