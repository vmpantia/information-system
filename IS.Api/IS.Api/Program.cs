using IS.Api.Contractors;
using IS.Api.DataAccess;
using IS.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DEV_SQL_CON");
builder.Services.AddDbContext<ISDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IUtilityService, UtilityService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
                        policy =>
                        {
                            policy.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
});

builder.Services.AddControllers();
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

app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
