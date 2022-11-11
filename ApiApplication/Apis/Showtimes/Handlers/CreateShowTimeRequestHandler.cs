using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

/// <summary>
/// 
/// </summary>
public class CreateShowTimeRequestHandler : IRequestHandler<CreateShowtimeRequest, ShowtimeResponse>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ShowtimeResponse> Handle(CreateShowtimeRequest request, CancellationToken cancellationToken) 
        => new();
}