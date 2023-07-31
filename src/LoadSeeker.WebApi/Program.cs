using CargoSeeker.DataAccess.Interfaces.Cargos;
using CargoSeeker.DataAccess.Interfaces.IGettransportsl;
using CargoSeeker.DataAccess.Interfaces.Transports;
using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.DataAccess.Repositories.Cargos;
using CargoSeeker.DataAccess.Repositories.Gettransports;
using CargoSeeker.DataAccess.Repositories.Transports;
using CargoSeeker.DataAccess.Repositories.Users;
using CargoSeeker.Service.Interfaces.Auth;
using CargoSeeker.Service.Interfaces.Cargos;
using CargoSeeker.Service.Interfaces.Commons;
using CargoSeeker.Service.Interfaces.GetTransports;
using CargoSeeker.Service.Interfaces.Notifications;
using CargoSeeker.Service.Interfaces.Transports;
using CargoSeeker.Service.Interfaces.Users;
using CargoSeeker.Service.Services.Auth;
using CargoSeeker.Service.Services.Cargos;
using CargoSeeker.Service.Services.Common;
using CargoSeeker.Service.Services.GetTransports;
using CargoSeeker.Service.Services.Notifications;
using CargoSeeker.Service.Services.Transports;
using CargoSeeker.Service.Services.Users;
using CargoSeeker.WebApi.Configurations;
using CargoSeeker.WebApi.Configurations.Layers;
using CargoSeeker.WebApi.MiddleWares;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
//->DI Containers
//builder.Services.AddScoped<IUsersRepository,UserRepository>();
//builder.Services.AddScoped<IFileService, FileService>();
//builder.Services.AddScoped<IUserService,UserService>();

//builder.Services.AddScoped<ICargoRepository,CargoRepository>();
//builder.Services.AddScoped<ICargoService, CargoService>();

//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddSingleton<ISmsSender,SmsSender>();

//builder.Services.AddScoped<ITransportService,TransportService>();
//builder.Services.AddScoped<ITransportRepository,TransportRepository>();
//builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddScoped<IGettransport,GettransportRepository>();
//builder.Services.AddScoped<IGetTransportService,GetTransportService>();

builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();
builder.ConfigureCORSPolicy();
builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();

//->DI Containers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlerMiddlewara>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();