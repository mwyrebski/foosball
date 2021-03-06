﻿using Foosball.Domain;
using Foosball.Infrastructure.Persistence;
using Foosball.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Foosball
{
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
            services.AddDbContext<FoosballDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("FoosballDatabase")) 
            );

            services.AddScoped<IGameRepository, GameRepository>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<FoosballDbContext>()
                    .Database.Migrate();
            }

            app.UseMiddleware<FoosballExceptionHandlingMiddleware>();

            app.UseMvc();
        }
    }
}
