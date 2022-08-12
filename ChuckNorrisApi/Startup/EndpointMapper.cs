using Services;

namespace ChuckNorrisApi.Refactored.Startup;

public static partial class EndpointMapper
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapJokeEndPoints();
        app.MapRandomEndPoints();

        return app;
    }

    public static WebApplication MapJokeEndPoints(this WebApplication app)
    {
        app.MapGet("/joke/{topic?}", (string? topic, IChuckNorrisRespositoryAPI chuckNorrisRespositoryAPI) => {
            return chuckNorrisRespositoryAPI.SearchChuckJokes(topic);
        });

        app.MapPost("/jokebycategory/{category}", (string category, IChuckNorrisRespositoryAPI chuckNorrisRespositoryAPI) => {
            return chuckNorrisRespositoryAPI.GetJokeByCategory(category);
        });

        return app;
    }

    public static WebApplication MapRandomEndPoints(this WebApplication app)
    {
        app.MapPut("/random", (IChuckNorrisRespositoryAPI chuckNorrisRespositoryAPI) =>
        {
            return chuckNorrisRespositoryAPI.Joke();
        });

        return app;
    }
}

