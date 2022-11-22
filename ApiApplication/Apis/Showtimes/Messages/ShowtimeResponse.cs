using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ApiApplication.Apis.Showtimes.Messages;

public class ShowtimeResponse
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
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
    public Movie Movie { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int AuditoriumId { get; set; }
}