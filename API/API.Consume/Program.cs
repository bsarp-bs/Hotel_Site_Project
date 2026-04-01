using API.BusinessLayer.Concrete_Manager;
using API.BusinessLayer.Service;
using API.Consume.Map;
using API.DataAccessLayer.Abstract;
using API.DataAccessLayer.Concrete_Context;
using API.DataAccessLayer.EntityFramework;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// Services - DAL
builder.Services.AddScoped<IRoomService, RoomManagerBL>();
builder.Services.AddScoped<IRoomDAL, EFRoomDAL>();

builder.Services.AddScoped<ITeamService, TeamManagerBL>();
builder.Services.AddScoped<ITeamDAL, EFTeamDAL>();

builder.Services.AddScoped<IDutyService, DutyManagerBL>();
builder.Services.AddScoped<IDutyDAL, EFDutyDAL>();

builder.Services.AddScoped<IReffService, ReffManagerBL>();
builder.Services.AddScoped<IReffDAL, EFReffDAL>();

builder.Services.AddScoped<ISubscribeService, SubscribeManagerBL>();
builder.Services.AddScoped<ISubscribeDAL, EFSubscribeDAL>();

builder.Services.AddScoped<IBookingService, BookingManagerBL>();
builder.Services.AddScoped<IBookingDAL, EFBookingDAL>();

// CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelApiConsume", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel API V1");
    });
}

app.UseHttpsRedirection();

app.UseCors("HotelApiConsume");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
