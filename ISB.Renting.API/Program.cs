using ISB.Renting.Data;
using ISB.Renting.Root;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add IConfiguration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

CompositionRoot.injectDependencies(builder.Services, builder.Configuration);

var app = builder.Build();

//using(var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<IsbDbContext>();
//    context.Database.Migrate();
//}

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
