using Microsoft.EntityFrameworkCore;
using Haircare.Models;

public class HairCareDbContext : DbContext
{
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    public HairCareDbContext(DbContextOptions<HairCareDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stylist>().HasData([
            new Stylist() {Id = 1, FirstName="Jess", LastName="Oneal", Email="jOneal@gmail.com", PhoneNumber="1-615-435-6829"},
            new Stylist() {Id = 2, FirstName="Maria", LastName="Gonzales", Email="m.gonzales@example.com", PhoneNumber="1-615-123-4567"},
            new Stylist() {Id = 3, FirstName="David", LastName="Smith", Email="d.smith@example.com", PhoneNumber="1-615-987-6543"}
        ]);

        modelBuilder.Entity<Customer>().HasData([
            new Customer() {Id=1, FirstName="John", LastName="Edwards", Email="je@yahoo.com", PhoneNumber="1-615-555-5555"},
            new Customer() {Id=2, FirstName="Alice", LastName="Williams", Email="a.williams@example.com", PhoneNumber = "1-615-222-3333"},
            new Customer() {Id = 3, FirstName="Robert", LastName="Brown", Email="r.brown@example.com", PhoneNumber = "1-615-444-6666"}
        ]);

        modelBuilder.Entity<Service>().HasData([
            new Service() {Id = 1, Name="Color", Price=10},
            new Service() {Id = 2, Name="Cut", Price=5},
            new Service() {Id = 3, Name="Wax", Price=15},
            new Service() {Id = 4, Name="Braid", Price=20}
        ]);
    }
}