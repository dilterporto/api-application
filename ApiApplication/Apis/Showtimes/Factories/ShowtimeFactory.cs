using System;
using System.Threading.Tasks;
using ApiApplication.Apis.Showtimes.Messages;
using ApiApplication.Database.Entities;
using ApiApplication.Integrations.Imdb;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace ApiApplication.Apis.Showtimes.Factories;

public interface IShowtimeFactory
{
    Task<ShowtimeEntity> CreateAsync(CreateShowtimeRequest createShowtimeRequest);
}

public class ShowtimeFactory : IShowtimeFactory
{
    private readonly IMapper _mapper;
    private readonly IImdbApi _imdbApi;
    private readonly string _imdbApiKey;

    public ShowtimeFactory(IMapper mapper, IImdbApi imdbApi, IOptions<ImdbOptions> imdbOptions)
    {
        _mapper = mapper;
        _imdbApi = imdbApi;
        _imdbApiKey = imdbOptions.Value.ApiKey;
    }
    
    public async Task<ShowtimeEntity> CreateAsync(CreateShowtimeRequest createShowtimeRequest)
    {
        try
        {
            var movieFetched = await _imdbApi.GetTitleByIdAsync(_imdbApiKey, createShowtimeRequest.Movie.ImdbId);
            if (movieFetched is null)
                throw new Exception($"movie {createShowtimeRequest.Movie.ImdbId} not found");

            createShowtimeRequest.Movie = _mapper.Map<MovieRequest>(movieFetched);

            return _mapper.Map<ShowtimeEntity>(createShowtimeRequest);
        }
        catch (Exception e)
        {
            throw new Exception($"movie {createShowtimeRequest.Movie.ImdbId} not found");
        }
    }
}