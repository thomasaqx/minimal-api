using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domains.DTOs;
using minimal_api.Infrastructure.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseMySql(
    builder.Configuration.GetConnectionString("mysql"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
  );
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO, AppDbContext context) =>
{
    var administrator = context.Administrators.FirstOrDefault(x => x.Email == loginDTO.Email && x.Password == loginDTO.Password);
    if (administrator is null)
    {
        return Results.Unauthorized();
    }
    
    return Results.Ok("login realizado com sucesso");
});


app.Run();