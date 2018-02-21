using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EE.Education.Site.EF.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EE.Education.Site.Infrastructure.Authentification
{
    public static class AuthHelper
    {
        public const string Issuer = "Education";
        public const string Audience = "http://localhost:5000";
        public const int Lifetime = 1;

        private const string SecretKey = "Education_secret!123";
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }

        /// <summary>
        /// Добавление аутентификации в IoC
        /// https://metanit.com/sharp/aspnet5/23.7.php
        /// </summary>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = Issuer,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = Audience,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddScoped<IAuthenticationService, AuthenticationService>();


            return services;
        }
        public static string CreateToken(ClaimsPrincipal principal)
        {
            var token = new JwtSecurityToken(
                issuer: AuthHelper.Issuer,
                audience: AuthHelper.Audience,
                notBefore: DateTime.Now,
                claims: principal.Claims,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthHelper.Lifetime)),
                signingCredentials: new SigningCredentials(AuthHelper.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public interface IAuthenticationService 
    {
        ClaimsPrincipal GetClaim(UserEntity user);
    }

    public class AuthenticationService : IAuthenticationService
    {
        public ClaimsPrincipal GetClaim(UserEntity user)
        {
            var claims = new[]
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("IsTeacher", user.IsTeacher.ToString()),
            };
            var identity = new ClaimsIdentity(claims);
            return new ClaimsPrincipal(identity);
        }
    }
}
