using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

public class GetShowtimesByFilterQueryRequestHandler : 
    IRequestHandler<GetShowtimesByFilterQueryRequest, IEnumerable<ShowtimeResponse>>
{
    public async Task<IEnumerable<ShowtimeResponse>> Handle(GetShowtimesByFilterQueryRequest request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}