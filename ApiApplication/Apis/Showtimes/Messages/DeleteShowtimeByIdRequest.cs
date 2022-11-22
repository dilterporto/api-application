using MediatR;

namespace ApiApplication.Apis.Showtimes.Messages;

public class DeleteShowtimeByIdRequest : IRequest<Unit>
{
    public int Id { get; set; }
    public DeleteShowtimeByIdRequest(int id) 
        => Id = id;
}