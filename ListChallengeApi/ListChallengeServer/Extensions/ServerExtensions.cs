using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace ListChallengeServer.ServerExtensions
{
  public static class ServerExtensions
  {
    public static void ConfigureMySql(this IServiceCollection services, IConfiguration config)
    {
      var connectionString = config["mysqlconnection:connectionString"];
      services.AddDbContext<RepositoryContext>(options => {
        options.UseMySql(connectionString);
      });
    }
  }
}