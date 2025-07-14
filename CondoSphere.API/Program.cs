using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Application.Services.Token;
using CondoSphere.Application.Services.User;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;
using CondoSphere.Infrastructure.Repositories;
using CondoSphere.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using FluentValidation;
using CondoSphere.Application.Authorization;
using CondoSphere.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var userManagementConnectionString = builder.Configuration.GetConnectionString("UserManagementConnection");
            var condominiumConnectionString = builder.Configuration.GetConnectionString("CondominiumConnection");

            builder.Services.AddDbContext<UserManagementDbContext>(options =>options.UseSqlServer(userManagementConnectionString));
            builder.Services.AddDbContext<CondominiumDbContext>(options =>options.UseSqlServer(condominiumConnectionString));

            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                //TODO: Aumentar a segurança da password (por enquanto vamos usar 123456)
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<UserManagementDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<int>>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });


            //Services-----------------------------------------------------------------------------------

            builder.Services.AddTransient<SeedDb>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICondominiumService, CondominiumService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(CondoSphere.Application.Mappings.CondominiumProfile).Assembly);
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IsCondoManagerPolicy", policy =>
                    policy.AddRequirements(new IsCondoManagerRequirement()));
            });

            builder.Services.AddScoped<IAuthorizationHandler, IsCondoManagerHandler>();


            builder.Services.AddControllers();
            builder.Services.AddValidatorsFromAssemblyContaining<CondoSphere.Application.Validators.Condominiums.CreateUpdateCondominiumDtoValidator>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<IUnitService, UnitService>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // 1. Define the security scheme (what kind of security we are using)
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // 2. Make Swagger UI apply this security scheme to all endpoints that have an [Authorize] attribute
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedDb>();
                await seeder.SeedAsync();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
