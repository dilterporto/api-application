using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Factories;
using ApiApplication.Apis.Showtimes.Messages;
using ApiApplication.Database;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

/// <summary>
/// 
/// </summary>
public class CreateShowTimeRequestHandler : IRequestHandler<CreateShowtimeRequest, ShowtimeResponse>
{
    private readonly IShowtimeFactory _showtimeFactory;
    private readonly IShowtimesRepository _showtimesRepository;

    public CreateShowTimeRequestHandler(IShowtimeFactory showtimeFactory, IShowtimesRepository showtimesRepository)
    {
        _showtimeFactory = showtimeFactory;
        _showtimesRepository = showtimesRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ShowtimeResponse> Handle(CreateShowtimeRequest request, CancellationToken cancellationToken)
    {
        var showtime = await _showtimeFactory.CreateAsync(request);
        
        _showtimesRepository.Add(showtime);
        
        return new ShowtimeResponse();
    }
}