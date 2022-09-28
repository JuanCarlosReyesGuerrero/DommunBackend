using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Data;
using RepositoryLayer.RespositoryPattern.IRepository;
using RepositoryLayer.RespositoryPattern.Repository;
using ServicesLayer.CustomServices;
using ServicesLayer.ICustomServices;
using System.Text;

namespace DependencyInjection
{
    public static class InyectarDependencia
    {
        public static void ConexionDataBases(this IServiceCollection services, IConfiguration Configuration)
        {
            ////var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            ////builder.Services.AddDbContext<ApplicationDbContext>(options =>
            ////    options.UseSqlServer(connectionString));

            //string dbConnectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString)));

            string dbConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(dbConnectionString));

            services.AddScoped<DbInitializer>();
        }

        public static void AutenticacionJwt(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,

                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretPassword"]))
                };
            });
        }

        public static void InyeccionServicios(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IBackOfficeRepository), typeof(BackOfficeRepository));
            services.AddScoped(typeof(IPropiedadRepository), typeof(PropiedadRepository));
            services.AddScoped(typeof(IAgenteRepository), typeof(AgenteRepository));

            services.AddTransient<IAgenteService, AgenteService>();
            services.AddTransient<IInmobiliariaService, InmobiliariaService>();
            services.AddScoped(typeof(IBackOfficeService), typeof(BackOfficeService));
            services.AddScoped(typeof(ICiudadService), typeof(CiudadService));
            services.AddScoped(typeof(IEstadoPropiedadService), typeof(EstadoPropiedadService));
            services.AddScoped(typeof(IFotografiaService), typeof(FotografiaService));
            services.AddScoped(typeof(IPropiedadService), typeof(PropiedadService));
            services.AddScoped(typeof(ITipoPropiedadService), typeof(TipoPropiedadService));

            services.AddTransient<IAuthToken, AuthToken>();
        }

        public static void UserIdentity(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}