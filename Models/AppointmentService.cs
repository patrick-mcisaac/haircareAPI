using System.ComponentModel.DataAnnotations;

namespace Haircare.Models;

public class AppointmentService
{
    public int Id { get; set; }
    [Required]
    public int ServiceId { get; set; }
    [Required]
    public int AppointmentId { get; set; }
}