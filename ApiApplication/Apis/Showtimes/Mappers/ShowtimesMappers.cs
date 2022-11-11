using ApiApplication.Apis.Showtimes.Messages;
using ApiApplication.Database.Entities;
using ApiApplication.Integrations.Imdb;
using AutoMapper;

namespace ApiApplication.Apis.Showtimes.Mappers;

public class ShowtimesMappers : Profile
{
    public ShowtimesMappers()
    {
        CreateMap<CreateShowtimeRequest, ShowtimeEntity>();
        CreateMap<TitleResponse, MovieRequest>();
        CreateMap<MovieRequest, MovieEntity>();
    }
}