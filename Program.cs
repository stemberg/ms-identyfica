using IDentyfica.Data;
using IDentyfica.Domain;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddScoped<PessoaDomain, PessoaDomain>();

builder.Services.AddDbContext<IDentyficaDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    assembly => assembly.MigrationsAssembly(typeof(IDentyficaDbContext).Assembly.FullName)
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8080")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin();
                          });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
