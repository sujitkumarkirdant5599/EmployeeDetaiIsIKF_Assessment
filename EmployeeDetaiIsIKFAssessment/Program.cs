using EmployeeDetaiIsIKFAssessment.DalLayer;
using EmployeeDetaiIsIKFAssessment.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeDetaiIsIKFAssessment", Version = "v1" });
});
builder.Services.AddScoped<EmployeeDAL>();
builder.Services.AddScoped<EmployeeBLL>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeDetaiIsIKFAssessment v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
