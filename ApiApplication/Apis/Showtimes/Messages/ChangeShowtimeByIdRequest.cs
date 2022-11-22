using System;
using System.Collections.Generic;
using System.ComponentModel;
using MediatR;
using Newtonsoft.Json;

namespace ApiApplication.Apis.Showtimes.Messages;

public class ChangeShowtimeByIdRequest : IRequest<ShowtimeResponse>
{
    [JsonIgnore]
    public int Id { get; }

    public ChangeShowtimeByIdRequest(int id, DateTime startDate, DateTime endDate, IEnumerable<string> schedule, Movie movie)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        Schedule = schedule;
        Movie = movie;
    }

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