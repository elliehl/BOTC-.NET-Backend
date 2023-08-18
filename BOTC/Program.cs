using BOTC.Data;
using BOTC.Repository;
using BOTC.Services;
using Dapper;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IContext, Context>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

