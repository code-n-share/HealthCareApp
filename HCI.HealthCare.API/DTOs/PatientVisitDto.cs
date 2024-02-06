namespace HCI.HealthCare.API.Models;

public class PatientVisitDto
{
    public PatientDto Patient { get; set; }

    public List<VisitDto> Visits { get; set; }
}