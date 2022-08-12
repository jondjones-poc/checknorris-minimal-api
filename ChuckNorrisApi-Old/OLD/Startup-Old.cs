//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Rewrite;
//using Microsoft.Net.Http.Headers;

//public class Startup
//{
//    private readonly IWebHostEnvironment _env;
//    private readonly IConfiguration _config;

//    public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
//    {
//        _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
//        _config = config ?? throw new ArgumentNullException(nameof(config));
//    }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        var weekly = 60 * 60 * 24 * 7;

//        services.AddUmbraco(_env, _config)
//            .AddBackOffice()
//            .AddWebsite()
//            .AddComposers()
//            .Build();

//        services.AddReCaptcha(_config.GetSection("ReCaptcha"));

//        if (_env.IsProduction())
//        {
//            services.AddResponseCaching();
//        }

//        services.AddMvc(options =>
//        {
//            options.CacheProfiles.Add("Weekly", new CacheProfile()
//            {
//                Duration = weekly,
//                VaryByQueryKeys = new[] { "*" }
//            });
//        });
//        services.AddOutputCaching(options =>
//        {
//            options.Profiles["Weekly"] = new OutputCacheProfile
//            {
//                Duration = weekly,
//                VaryByParam = "*"
//            };
//        });
//    }

//    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//    {
//        if (env.IsProduction())
//        {
//            var options = new RewriteOptions();
//            options.AddRedirectToHttpsPermanent();
//            options.AddRedirectToWwwPermanent();
//            app.UseRewriter(options);


//            app.UseExceptionHandler("/500.html");

//            app.UseOutputCaching();
//            app.UseCloudflareCacheTagMiddleware(new CacheTags("MyApplication,MyEnvironment,MyEnvironment-MyApplication"));

//            app.UseStaticFiles(new StaticFileOptions
//            {
//                OnPrepareResponse = ctx =>
//                {
//                    const int durationInSeconds = 60 * 60 * 24;
//                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
//                }
//            });

//            app.Use(async (context, next) =>
//            {
//                string path = context.Request.Path;

//                if (path.StartsWith("/umbraco/") == false)
//                {
//                    if (path.EndsWith(".css") || path.EndsWith(".js") || path.EndsWith(".svg") || path.EndsWith(".woff2"))
//                    {
//                        context.Response.Headers.Add("Cache-Control", "public, max-age=31536000");
//                    }
//                }

//                await next();
//            });
//        }

//        app.UseResponseCaching();
//        app.UseUmbraco()
//            .WithMiddleware(u =>
//            {
//                u.UseCustomRedirects();
//                u.UseBackOffice();
//                u.UseWebsite();
//            })
//            .WithEndpoints(u =>
//            {
//                u.UseInstallerEndpoints();
//                u.UseBackOfficeEndpoints();
//                u.UseWebsiteEndpoints();
//                u.UseCustomRoutingRules();
//            });

//    }
//}