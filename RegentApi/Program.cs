using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegentApi.core;
using RegentApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RegentDB_NewContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddMvc();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(Program).Assembly);
//builder.Services.AddAutoMapper(typeof(JobProfile).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 //builder.Services.AddTransient<IJobProfileRepository, JobRepository>();

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
