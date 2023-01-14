using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstWebApi.DataBase;
using MyFirstWebApi.Interfaces;

namespace MyFirstWebApi.Identity
{
    public static class Extensions
    {
        public static void UseApSlIdentity(this IServiceCollection services)
        {
            services.AddTransient<IIdentitiyService, IdentitiyService>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<IRng, Rng>();

            services.AddTransient<IUserRepository>(service =>
            {
                var config = service.GetRequiredService<IConfiguration>();
                var cn = config.GetConnectionString("Default");
                var options = new DatabaseOptions(cn);
                return new UserRepository(options);
            });

            services.AddTransient<IRefreshTokenRepository>(service =>
            {
                var config = service.GetRequiredService<IConfiguration>();
                var cn = config.GetConnectionString("Default");
                var options = new DatabaseOptions(cn);
                return new RefreshTokenRepository(options);
            });

            services.AddSingleton<IPasswordHasher<IPasswordService>, PasswordHasher<IPasswordService>>();
        }
    }
}