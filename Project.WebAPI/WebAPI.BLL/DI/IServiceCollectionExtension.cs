#region NameSpace
using Microsoft.Extensions.DependencyInjection;
using WebAPI.DAL;
using WebApp.Domain;
#endregion

namespace WebAPI.BLL.DI
{
    public static class IServiceCollectionExtension
    {
        #region AddRepository
        /// <summary>
        /// AddRepository
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IDALRepository, Repository>();

            return services;
        }
        #endregion
    }
}
