using CargoSeeker.DataAccess.Interfaces.Cargos;
using CargoSeeker.DataAccess.Interfaces.IGettransportsl;
using CargoSeeker.DataAccess.Interfaces.Transports;
using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.DataAccess.Repositories.Cargos;
using CargoSeeker.DataAccess.Repositories.Gettransports;
using CargoSeeker.DataAccess.Repositories.Transports;
using CargoSeeker.DataAccess.Repositories.Users;

namespace CargoSeeker.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IGettransport,GettransportRepository>();
        builder.Services.AddScoped<ITransportRepository,TransportRepository>();
        builder.Services.AddScoped<ICargoRepository,CargoRepository>();
        builder.Services.AddScoped<IUsersRepository,UserRepository>();
    }
}
