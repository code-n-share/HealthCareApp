namespace HCI.HealthCare.API.Exceptions;

public class PractitionerNotFoundException : Exception
{
    public PractitionerNotFoundException()
    {
    }

    public PractitionerNotFoundException(string name)
        : base($"Practitioner : {name} not found.")
    {
    }
}