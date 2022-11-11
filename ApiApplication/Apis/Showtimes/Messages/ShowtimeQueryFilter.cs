using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Apis.Showtimes.Messages;

/// <summary>
/// Filter showtimes
/// </summary>
public class ShowtimeQueryFilter
{
    /// <summary>
    /// Showtime date
    /// </summary>
    [FromQuery(Name = "date")]
    public DateTime? Date { get; set; }
        
    /// <summary>
    /// Movie Title
    /// </summary>
    [FromQuery(Name = "title")]
    public string MovieTitle { get; set; }
}