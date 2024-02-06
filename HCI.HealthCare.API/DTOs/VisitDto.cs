namespace HCI.HealthCare.API.Models;

public class VisitDto
{
    public string VisitId { get; set; }
    public string PractitionerId { get; set; }
    public DateOnly Date { get; set; }
    public string SlotTime { get; set; }
    public string Feedback { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set;}
}