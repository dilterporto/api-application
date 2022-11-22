using MediatR;

namespace ApiApplication.Apis.Showtimes.Messages;

public class GetShowtimeByIdQueryRequest : IRequest<ShowtimeResponse>
{
    public int Id { get; set; }
    public GetShowtimeByIdQueryRequest() { }
    public GetShowtimeByIdQueryRequest(int id) 
        => Id = id;
}