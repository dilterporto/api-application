using System.Collections.Generic;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Messages;

public class GetShowtimesByFilterQueryRequest : IRequest<IEnumerable<ShowtimeResponse>>
{
    public ShowtimeQueryFilter Filter { get; set; }
    public GetShowtimesByFilterQueryRequest() { }
    public GetShowtimesByFilterQueryRequest(ShowtimeQueryFilter filter) 
        => Filter = filter;
}