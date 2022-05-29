using Microsoft.EntityFrameworkCore;
using nh.health.infrastructure.dal.command;
using nh.health.domain.Repositories;
using nh.health.domain.Aggregates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? commandConnection = Environment.GetEnvironmentVariable("ConnectionStrings__Command");
if (string.IsNullOrWhiteSpace(commandConnection))
    throw new Exception("The command connection string could not be found.");
builder.Services.AddDbContext<CommandContext>(options => options.UseNpgsql(commandConnection));
builder.Services.AddScoped<ICommandContext, CommandContext>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IDoctorScheduleAggregateContext, DoctorScheduleAggregateContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
