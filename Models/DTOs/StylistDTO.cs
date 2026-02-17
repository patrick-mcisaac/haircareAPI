namespace Haircare.Models.DTO;

public class StylistDTO : PersonDTO
{
    public bool Active { get; set; } = true;
    public ICollection<AppointmentDTO> Appointments { get; set; }
}