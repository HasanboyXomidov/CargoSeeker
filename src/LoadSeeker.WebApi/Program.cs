using CargoSeeker.DataAccess.Interfaces.Users;
using CargoSeeker.DataAccess.Repositories.Users;
using CargoSeeker.Service.Interfaces.Commons;
using CargoSeeker.Service.Interfaces.Users;
using CargoSeeker.Service.Services.Common;
using CargoSeeker.Service.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//->DI Containers
builder.Services.AddScoped<IUsersRepository,UserRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService,UserService>();
//->DI Containers

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
