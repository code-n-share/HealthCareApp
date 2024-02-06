using System.ComponentModel.DataAnnotations;

namespace HCI.HealthCare.API.Models;

public class BookAppointmentDto
{
    public string PatientId { get; set; }
    public string PractitionerId { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
    public string SlotStartTime { get; set; }
    public string SlotEndTime { get; set; }
}