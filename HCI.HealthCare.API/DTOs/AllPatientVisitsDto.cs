namespace HCI.HealthCare.API.Models;

public class AllPatientVisitsDto : VisitDto
{
    public PatientDto Patient { get; set; }
    public PractitionerDto Practitioner { get; set; }
}