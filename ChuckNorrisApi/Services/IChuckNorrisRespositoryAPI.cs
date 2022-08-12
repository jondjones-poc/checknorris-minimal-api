namespace Services
{
    public interface IChuckNorrisRespositoryAPI
    {
        Task<string> SearchChuckJokes(string? topic);

        Task<string> GetJokeByCategory(string category);

        Task<string> Joke();
    }
}
