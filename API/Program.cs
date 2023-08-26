using Core.Infraestructure;
using Core.Services.Imp;
using Core.Services.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(option =>
{
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}).ConfigureApiBehaviorOptions(option =>{
    option.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddSwaggerGen();

var services = builder.Services;
var configuration = builder.Configuration;

configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.Local.json");

services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DataBaseConnection")));

services.AddTransient<ICustomerService, CustomerService>();
services.AddTransient<IPostService, PostService>();


services.AddTransient<ICustomerRepository, CustomerRepository>();
services.AddTransient<IPostRepository, PostRepository>();

services.AddCors(options => options.AddPolicy("CorsPolicy", builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthentication();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();
