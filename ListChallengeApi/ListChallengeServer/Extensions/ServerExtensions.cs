using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities;
using Contracts;
using Repository;

namespace ListChallengeServer.ServerExtensions
{
  public static class ServerExtensions
  {
    public static void ConfigureMySql(this IServiceCollection services, IConfiguration config)
    {
      // var connectionString = config["mysqlconnection:connectionString"];
      // services.AddDbContext<RepositoryContext>(options => {
      //   options.UseMySql(connectionString);
      // });
    }
    public static void ConfigureRepository(this IServiceCollection services)
    {
      services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
  }
}