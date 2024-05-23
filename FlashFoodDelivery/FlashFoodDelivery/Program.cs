using Business_Layer.AutoMapper;
using Business_Layer.DataAccess;
using Business_Layer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", build => build.AllowAnyMethod()
        .AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(hostname => true).Build());
    });

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string connectionstr = config.GetConnectionString("db");
builder.Services.AddDbContext<FastFoodDeliveryDBContext>(option => option.UseSqlServer(connectionstr));
builder.Services.AddAutoMapper(typeof(ApplicationMapper));

// add services repository pattern
//builder.services.addtransient<iproductrepository, productmanager>();
//builder.services.addtransient<icategoryrepository, categorymanager>();
builder.Services.AddTransient<IMenuFoodItemRepository, MenuItemFoodRepository>();

var app = builder.Build();

// configure the http request pipeline.

app.MapControllers();
app.MapGet("/", () => "hello world");
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.Run();