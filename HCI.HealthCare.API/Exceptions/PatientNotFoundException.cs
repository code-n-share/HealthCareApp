namespace HCI.HealthCare.API.Exceptions;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException()
    {
    }

    public PatientNotFoundException(string patientId)
        : base($"PatientId : {patientId} not found.")
    {
    }
}