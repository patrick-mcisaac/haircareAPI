using System.ComponentModel.DataAnnotations;

namespace Haircare.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int StylistId { get; set; }
    [Required]
    public DateTime AppointmentTime { get; set; }

    public Customer Customer { get; set; }
    public Stylist Stylist { get; set; }
}