using PCCO.DataAccess.Repositories.Implementations;
using PCCO.DataAccess.Repositories.Interfaces;
using PCCO.Services.Implementations;
using PCCO.Services.Interfaces;

namespace PCCO.Models.Extensions
{
    public static class AddServisesExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services
            .AddScoped<IUserPageService, UserPageService>()
            .AddScoped<IRegistratorPageService, RegistratorPageSevice>()
            .AddScoped<IAdministratorPageService, AdministratorPageService>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
            /*.AddScoped<IUserRepository, ApplicationUserRepository>();
            .AddTransient<IUserPageService, UserPageService>()
            .AddTransient<IEditorPageService, EditorPageSevice>()
            .AddTransient<IAdministratorPageService, AdministratorPageService>()
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IAdministratorPageService, AdministratorPageService>()*/

            return services;
        }
    }
}
