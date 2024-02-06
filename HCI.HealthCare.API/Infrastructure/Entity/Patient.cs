namespace HCI.HealthCare.API.Infrastructure;

public class Patient
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}