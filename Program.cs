using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem_Final;
using UniversityManagementSystem_Final.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var filePath = Path.Combine(AppContext.BaseDirectory, "UniversityManagementSystem_Final.xml");
    options.IncludeXmlComments(filePath);
}
);
var s = builder.Configuration.GetConnectionString("UniversityManagementDb");
builder.Services.AddDbContext<UniversityManagementSystemDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UniversityManagementDb"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


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
