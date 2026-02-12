using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Scalar.AspNetCore;
using Haircare.Models;
using Haircare.Models.DTO;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehaviour", true);

builder.Services.AddNpgsql<HairCareDbContext>(builder.Configuration["haircareDbConnectionString"]);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "My API Documentation";
        options.Theme = ScalarTheme.Saturn;
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

// Customers

app.MapGet("/api/customers", (HairCareDbContext db) =>
{
    return Results.Ok(db.Customers.Select(c => new CustomerDTO
    {
        Id = c.Id,
        FirstName = c.FirstName,
        LastName = c.LastName,
        Email = c.Email,
        PhoneNumber = c.PhoneNumber
    }).ToList());
});

app.MapGet("/api/customers/{id}", (int id, HairCareDbContext db) =>
{
    Customer? customer = db.Customers.SingleOrDefault(c => c.Id == id);

    if (customer == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(new CustomerDTO
    {
        Id = customer.Id,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        Email = customer.Email,
        PhoneNumber = customer.PhoneNumber
    });
});

// Appointments
app.MapGet("api/appointments", (HairCareDbContext db) =>
{
    return Results.Ok(db.Appointments
    .Include(a => a.Customer)
    .Select(a =>
             new AppointmentDTO()
             {
                 Id = a.Id,
                 AppointmentTime = a.AppointmentTime,
                 CustomerId = a.CustomerId,
                 StylistId = a.StylistId,
                 Customer = a.Customer == null ? null : new CustomerDTO()
                 {
                     Id = a.Customer.Id,
                     FirstName = a.Customer.FirstName,
                     LastName = a.Customer.LastName,
                     Email = a.Customer.Email,
                     PhoneNumber = a.Customer.PhoneNumber
                 }
             }
        ));
});

app.MapPost("api/appointments", (HairCareDbContext db, Appointment appointment) =>
{
    appointment.Id = db.Appointments.Count() + 1;
    db.Appointments.Add(appointment);
    db.SaveChanges();
    return Results.Created($"/api/appointments/{appointment.Id}", appointment);
});


// Stylists

app.MapGet("api/stylists", (HairCareDbContext db) =>
{
    return Results.Ok(db.Stylists.Select(s => new StylistDTO()
    {
        Id = s.Id,
        FirstName = s.FirstName,
        LastName = s.LastName,
        Email = s.Email,
        PhoneNumber = s.PhoneNumber
    }));
});


app.Run();


