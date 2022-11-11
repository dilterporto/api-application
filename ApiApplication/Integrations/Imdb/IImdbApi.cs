using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace ApiApplication.Integrations.Imdb;

public interface IImdbApi
{
    [Get("/en/API/Title/{apiKey}/{id}")]
    Task<TitleResponse> GetTitleByIdAsync(string apiKey, string id);
}

public class TitleResponse
{
    [JsonProperty("id")]
    public string ImdbId { get; set; }
    
    [JsonProperty("stars")]
    public string Stars { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("releaseDate")]
    public DateTime ReleaseDate { get; set; }
}