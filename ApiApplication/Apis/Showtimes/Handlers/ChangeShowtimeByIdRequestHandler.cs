using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

public class ChangeShowtimeByIdRequestHandler : IRequestHandler<ChangeShowtimeByIdRequest, ShowtimeResponse>
{
    public async Task<ShowtimeResponse> Handle(ChangeShowtimeByIdRequest request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}