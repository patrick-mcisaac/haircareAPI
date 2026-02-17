namespace Haircare.Models.DTO;

public class CustomerDTO : PersonDTO
{
    public ICollection<AppointmentDTO> Appointments { get; set; }
}