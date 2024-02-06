using HCI.HealthCare.API.Models;

namespace HCI.HealthCare.API.Domain;

public interface IHealthCareService
{
    Task<PatientVisitDto?> GetPatientVisitInfo(string patientId);
    Task<string> BookAppointment(BookAppointmentDto bookAppointmentDto);
    Task<IEnumerable<AllPatientVisitsDto>> GetAllVisitData();
    Task<IEnumerable<PatientDto?>> GetAllPatients();
    Task<IEnumerable<PractitionerDto>> GetAllPractitioners();
}