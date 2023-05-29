using Backend.Application;
using Backend.Application.Common.Interfaces;
using Persistence;
using Backend.WebUI.Filters;
using Backend.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;
using Backend.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using MediatR;

namespace Backend.WebUI;

public class Startup
{
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();
        services.AddInfrastructure(Configuration);

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
            loggingBuilder.AddDebug();
        });

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        // Register the IFileStorageService with the correct storage directory
        services.AddScoped<IFileStorageService>(provider =>
        {
            var env = provider.GetRequiredService<IWebHostEnvironment>();
            var storageDirectory = Path.Combine(env.ContentRootPath, "wwwroot", "Drawings");
            return new LocalFileStorageService(storageDirectory);
        });

        services.AddMediatR(typeof(Startup));
        
        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

/*       services.AddRazorPages();
*/
        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options => 
            options.SuppressModelStateInvalidFilter = true);

        // In production, the Angular files will be served from this directory
     /*   services.AddSpaStaticFiles(configuration => 
            configuration.RootPath = "ClientApp/dist");*/

        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "Backend API";
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });


        services.AddCors(o => o.AddPolicy("TE_Policy", builder =>
        {
            /* builder.WithOrigins(Configuration.GetSection("AllowedOrigins").Value.Split(","))
               .AllowCredentials().WithHeaders(Configuration.GetSection("AllowedHeaders").Value.Split(","))
               .WithMethods(Configuration.GetSection("AllowedMethods").Value.Split(","));*/
            /*   builder.WithOrigins(Configuration.GetSection("AllowedOrigins").Value.Split(","));
               builder.AllowCredentials().WithHeaders(Configuration.GetSection("AllowedHeaders").Value.Split(","));
               builder.AllowAnyMethod()
                          .AllowAnyHeader();*/
/*
            builder.WithOrigins(Configuration.GetSection("AllowedOrigins").Value.Split(","))
               .AllowCredentials().WithHeaders(Configuration.GetSection("AllowedHeaders").Value.Split(","))
               .AllowAnyHeader();*/

            builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();

        }));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseCors("TE_Policy");
        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseFileServer();
        if (!env.IsDevelopment())
        {
            //app.AddSigningCredentials();
            //app.UseSpaStaticFiles();
        }

/*        app.UseSwaggerUi3(settings =>
        {
            settings.Path = "/api";
            settings.DocumentPath = "/api/specification.json";
        });*/


/*        app.UseSwagger();
        app.UseSwaggerUi3(settings =>
        {
            settings.Path = "/api";
        });*/

        app.UseOpenApi();
        app.UseSwaggerUi3(settings =>
        {
            settings.Path = "/api";
        });

        app.UseRouting();

        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
            //endpoints.MapRazorPages();
        });

       /* 
        * 
        *  file.path
        * 
        * 
        * 
        * 
        * app.UseSpa(spa =>
        {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

            if (env.IsDevelopment())
            {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer(Configuration["SpaBaseUrl"] ?? "http://localhost:4200");
            }
        });*/
    }
}
