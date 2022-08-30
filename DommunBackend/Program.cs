using DependencyInjection;
using RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Connection String  

builder.Services.ConexionDataBases(builder.Configuration);

#endregion

#region Services Autentication  

builder.Services.AutenticacionJwt(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Services Injected  

builder.Services.InyeccionServicios(builder.Configuration);

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
    app.UseItToSeedSqlServer();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
