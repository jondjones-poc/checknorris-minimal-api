using ChuckNorrisApi;

public class ChuckNorrisRespositoryAPI : IChuckNorrisRespositoryAPI
{
    private readonly IHttpClientFactory _clientFactory;

    public ChuckNorrisRespositoryAPI(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public Task<string> SearchChuckJokes(string? topic)
    {
        if (string.IsNullOrEmpty(topic))
        {
            return Task.FromResult(string.Empty);
        }

        return MakeHttpWebRequest("https://api.chucknorris.io/jokes/random");
    }
    public Task<string> Joke()
    {
        return MakeHttpWebRequest("https://api.chucknorris.io/jokes/random");
    }

    public Task<string> GetJokeByCategory(string category)
    {
        return MakeHttpWebRequest("https://api.chucknorris.io/jokes/random?category=" + category);
    }

    public async Task<string> MakeHttpWebRequest(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}