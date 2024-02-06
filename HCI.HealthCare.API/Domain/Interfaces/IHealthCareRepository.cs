using HCI.HealthCare.API.Models;

public interface IHealthCareRepository
{
    Task<PatientVisitDto?> GetPatientVisit(string patientVisitId);
    Task<PatientDto?> GetPatient(string patientId);
    Task<PatientDto?> GetPatientFullDetails(string patientId);
    Task<PractitionerDto?> GetPractioner(string name);

    Task<string> BookAppointment(
        string patientId, 
        string practitionerId,
        DateOnly date,
        (int hours,int minutes) startTime,
        (int hours,int minutes) endTime
    );

    Task<IEnumerable<AllPatientVisitsDto>> GetAllVisitData();
    Task<IEnumerable<PatientDto>> GetAllPatients();
    Task<IEnumerable<PractitionerDto>> GetAllPractitioners();
}