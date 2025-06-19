using DotNet_Test_TTSS.Application.Interfaces;
using DotNet_Test_TTSS.Data;
using DotNet_Test_TTSS.Infrastructure.Repositories;
using DotNet_Test_TTSS.Interfaces;
using DotNet_Test_TTSS.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Error;       
    });


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<RedisDbContext>();
builder.Services.AddDbContext<SupabaseDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "Assignments_";
});

builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<ITrucksRepository, TrucksRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();


