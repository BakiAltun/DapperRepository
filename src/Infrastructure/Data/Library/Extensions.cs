using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Data.Library;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Library
{
    public static class Extensions
    {
        public static void AddDapperSql(this IServiceCollection services, Action<DapperOptions> config)
        {
            var options = new DapperOptions();
            config(options);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>(f =>
            {
                var sqlConnection = new SqlConnection(options.ConnectionString);
                return new UnitOfWork(sqlConnection);
            });
            services.AddScoped<IUnitOfWorkConnection>(serviceProvider =>
            {
                return (UnitOfWork)serviceProvider.GetRequiredService<IUnitOfWork>();
            });

            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                return type.Name;
            };
        }
    }
}