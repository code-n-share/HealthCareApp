namespace HCI.HealthCare.API.Infrastructure;

public class PatientVisit
{
    public string VisitId { get; set; }
    public string PatientId { get; set; }
    public string PractitionerId { get; set; }
    public DateOnly Date { get; set; }
    public Slot Slot { get; set; }
    public string Feedback { get; set; }
    public VisitStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}