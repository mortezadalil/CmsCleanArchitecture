using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cms.Api.Presenters;
using Cms.Core.IRepositories;
using Cms.Core.IUseCases;
using Cms.Core.Queries;
using Cms.Core.Services;
using Cms.Core.UseCases;
using Cms.Infrastructure.Database;
using Cms.Infrastructure.Database.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Cms.Api
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
      services.AddDbContext<CmsDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("CmsDatabase")));

      services.AddScoped<IPostService, PostService>();
      services.AddScoped<IPostRepository, PostRepository>();
      services.AddScoped<IAddPostUseCase, AddPostUseCase>();
      services.AddScoped<IDeletePostUseCase, DeletePostUseCase>();
      services.AddScoped(typeof(PostApiPresenter<>));
      services.AddScoped<CmsDbContext>();
      services.AddScoped<ITokenService, TokenService>();
      services.AddControllers();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
      {
          options.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateAudience = false,
              ValidateIssuer = false,
              ValidateIssuerSigningKey = true,
              ClockSkew = TimeSpan.Zero,
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"])),
          };
      });

      services.AddMediatR(typeof(Startup));
      services.AddMediatR(typeof(GetAllPostQuery).GetTypeInfo().Assembly);
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
