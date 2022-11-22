using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

public class GetShowtimeByIdQueryRequestHandler : IRequestHandler<GetShowtimeByIdQueryRequest, ShowtimeResponse>
{
    public async Task<ShowtimeResponse> Handle(GetShowtimeByIdQueryRequest request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
