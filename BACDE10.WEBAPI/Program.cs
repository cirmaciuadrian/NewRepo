using BACDE10.BusinessLogic.Models.Options;
using BACDE10.WEBAPI.Installers.Extensions;
using BACDE10.WEBAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.InstallServicesInAssembly(builder.Configuration);

builder.Services.AddOptions<HeadersConfigSettings>().Bind(builder.Configuration.GetSection("Headers"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<HeadersValidationMiddleware>();
app.UseMiddleware<UserDetailsMiddleware>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
