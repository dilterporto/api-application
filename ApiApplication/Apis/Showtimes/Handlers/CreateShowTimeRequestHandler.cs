using System.Threading;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Factories;
using ApiApplication.Apis.Showtimes.Messages;
using ApiApplication.Database;
using AutoMapper;
using MediatR;

namespace ApiApplication.Apis.Showtimes.Handlers;

/// <summary>
/// 
/// </summary>
public class CreateShowTimeRequestHandler : IRequestHandler<CreateShowtimeRequest, ShowtimeResponse>
{
    private readonly IShowtimeFactory _showtimeFactory;
    private readonly IShowtimesRepository _showtimesRepository;
    private readonly IMapper _mapper;

    public CreateShowTimeRequestHandler(IShowtimeFactory showtimeFactory, IShowtimesRepository showtimesRepository, IMapper mapper)
    {
        _showtimeFactory = showtimeFactory;
        _showtimesRepository = showtimesRepository;
        _mapper = mapper;
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
        var showtimeEntity = _showtimesRepository.Add(showtime);
        
        return _mapper.Map<ShowtimeResponse>(showtimeEntity);
    }
}