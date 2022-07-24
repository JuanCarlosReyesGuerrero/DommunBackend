using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.RespositoryPattern;
using ServiceLayer.ClassServices;
using ServiceLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

#region Services Injected  

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddTransient<IZonaService, ZonaService>();
builder.Services.AddTransient<ITipoZonaService, TipoZonaService>();
builder.Services.AddTransient<IDepartamentoService, DepartamentoService>();
builder.Services.AddTransient<IMunicipioService, MunicipioService>();

#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
