using System.ComponentModel.DataAnnotations;

namespace Haircare.Models.DTO;

public class AppointmentDTO
{
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int StylistId { get; set; }
    [Required]
    public DateTime AppointmentTime { get; set; }

    public CustomerDTO Customer { get; set; }
    public StylistDTO Stylist { get; set; }
}