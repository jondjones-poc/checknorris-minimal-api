using ChuckNorrisApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IChuckNorrisRespositoryAPI, ChuckNorrisRespositoryAPI>();
builder.Services.AddTransient<IChuckNorrisRespositoryAPI, ChuckNorrisRespositoryAPI>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/joke/{topic?}", (string? topic, IChuckNorrisRespositoryAPI chuckNorrisRespositoryAPI) => {
    return chuckNorrisRespositoryAPI.SearchChuckJokes(topic);
});

app.MapPost("/jokebycategory/{category}", (string category, IChuckNorrisRespositoryAPI chuckNorrisRespositoryAPI) => {
    return chuckNorrisRespositoryAPI.GetJokeByCategory(category);
});

app.MapPut("/random", (IChuckNorrisRespositoryAPI chuckNorrisRespositoryAPI) =>
{
    return chuckNorrisRespositoryAPI.Joke();
});

app.Run();