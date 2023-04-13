using Buber.Application;
using Buber.Infrastructure;
using BuberDinner.Errors;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory,BuberDinnerProblemDetailsFactory>();
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
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
app.UseExceptionHandler("/error");

app.Map("/error",(HttpContext context) => 
{

    Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();

}); 
//app.UseMiddleware<ErrorHandelingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
