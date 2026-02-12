namespace Haircare.Models;

public class Customer : Person
{
    public ICollection<Appointment> Appointments { get; set; }
}