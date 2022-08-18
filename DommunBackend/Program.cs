using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using RepositoryLayer.RespositoryPattern;
using RepositoryLayer.RespositoryPattern.Interface;
using RepositoryLayer.RespositoryPattern.Repository;
using ServicesLayer.Interface;
using ServicesLayer.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Connection String  

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Services Autentication  

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretPassword"]))
    };
});

//builder.Services
//    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//                   options.TokenValidationParameters = new TokenValidationParameters()
//                   {
//                       ValidateIssuer = true,
//                       ValidateAudience = true,
//                       ValidateLifetime = true,
//                       ValidateIssuerSigningKey = true,
//                       ValidIssuer = builder.Configuration["JWT:Issuer"],
//                       ValidAudience = builder.Configuration["JWT:Audience"],
//                       ClockSkew = TimeSpan.Zero,
//                       IssuerSigningKey = new SymmetricSecurityKey(
//                           Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretPassword"])
//                       )
//                   };
//               });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Services Injected  

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBackOfficeRepository), typeof(BackOfficeRepository));

builder.Services.AddTransient<IAgenteService, AgenteService>();
builder.Services.AddTransient<IInmobiliariaService, InmobiliariaService>();
builder.Services.AddScoped(typeof(IBackOfficeService), typeof(BackOfficeService));
builder.Services.AddScoped(typeof(ICiudadService), typeof(CiudadService));
builder.Services.AddScoped(typeof(IEstadoPropiedadService), typeof(EstadoPropiedadService));
builder.Services.AddScoped(typeof(IFotografiaService), typeof(FotografiaService));
builder.Services.AddScoped(typeof(IFotografiaPropiedadService), typeof(FotografiaPropiedadService));
builder.Services.AddScoped(typeof(IPropiedadService), typeof(PropiedadService));
builder.Services.AddScoped(typeof(ITipoPropiedadService), typeof(TipoPropiedadService));

builder.Services.AddTransient<IAuthToken, AuthToken>();

#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


#region Shows UseCors with CorsPolicyBuilder.

app.UseCors(builder =>
{
    builder
    //.WithOrigins("https://www.yogihosting.com")
    //https://www.yogihosting.com/aspnet-core-enable-cors/
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseCors();

#endregion

//Configure the HTTP request pipeline.
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
