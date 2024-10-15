using Microsoft.EntityFrameworkCore;
using StargateAPI.Data;
using StargateAPI.Repositories;
using StargateAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAstroDutyRepository, AstroDutyRepository>();
builder.Services.AddScoped<IAstroDutyService, AstroDutyService>();
builder.Services.AddDbContext<StargateContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("StarbaseApiDatabase")));

builder.Services.AddTransient<Seeder>();



var app = builder.Build();

app.UseCors(builder =>
{
	builder.AllowAnyOrigin();
	builder.AllowAnyMethod();
	builder.AllowAnyHeader();
});

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<StargateContext>();
	if (db.Database.GetPendingMigrations().Any())
	{
		db.Database.Migrate();
	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
	seeder.Seed();
}

app.Run();


