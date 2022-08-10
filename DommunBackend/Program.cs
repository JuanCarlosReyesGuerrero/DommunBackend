using DommunBackend.Data;
using DommunBackend.RepositoryLayer.RespositoryPattern.ClassRepository;
using DommunBackend.RepositoryLayer.RespositoryPattern.Interface;
using DommunBackend.ServiceLayer.ClassServices;
using DommunBackend.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultUI()
           .AddDefaultTokenProviders();

#region Services Injected 

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IMunicipioRepository), typeof(MunicipioRepository));
builder.Services.AddScoped(typeof(IAutenticacionAppRepository), typeof(AutenticacionAppRepository));

builder.Services.AddTransient<IZonaService, ZonaService>();
builder.Services.AddTransient<ITipoZonaService, TipoZonaService>();
builder.Services.AddTransient<IDepartamentoService, DepartamentoService>();
builder.Services.AddTransient<IMunicipioService, MunicipioService>();
builder.Services.AddTransient<IAutenticacionAppService, AutenticacionAppService>();
builder.Services.AddTransient<IAgenteService, AgenteService>();
builder.Services.AddTransient<IZonificacionService, ZonificacionService>();
builder.Services.AddTransient<IPlanMembresiaService, PlanMembresiaService>();

//builder.Services.AddTransient<IUsuarioService, UsuarioService>();
//builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<IAuthToken, AuthToken>();

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



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
