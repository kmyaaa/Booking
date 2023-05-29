using Booking.Application.Abstractions;
using Booking.Application.Reservations.Commands;
using Booking.Application.Reservations.Queries;
using Booking.Common;
using Booking.Data;
using Booking.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("MainConnectionString");
builder.Services.AddDbContext<BookingDbContext>(x => x.UseSqlServer(cs));

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddMediatR(typeof(CreateReservationCommand));
builder.Services.AddMediatR(typeof(UpdateReservationCommand));
builder.Services.AddMediatR(typeof(DeleteReservationCommand));
builder.Services.AddMediatR(typeof(GetReservationByIdQuery));
builder.Services.AddMediatR(typeof(GetReservationsByTripIdQuery));
builder.Services.AddMediatR(typeof(GetReservationsByUserIdQuery));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();


app.Run();
