namespace Haircare.Models;

public class Stylist : Person
{
    public bool Active { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}