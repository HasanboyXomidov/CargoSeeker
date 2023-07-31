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

namespace CargoSeeker.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICargoService, CargoService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
        builder.Services.AddScoped<ITransportService, TransportService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IGetTransportService,GetTransportService>();
    }
}
