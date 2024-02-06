using HCI.HealthCare.API.Models;

namespace HCI.HealthCare.API.Infrastructure;

public class HealthCareRepository : IHealthCareRepository
{
    HealthCareData _healthCareData;
    public HealthCareRepository()
    {
        _healthCareData = new HealthCareData();
    }

    public async Task<PatientVisitDto?> GetPatientVisit(string patientId)
    {
        var patient = _healthCareData.patients.FirstOrDefault(p => p.Id == patientId);
        if (patient == null)
        {
            return await Task.FromResult<PatientVisitDto?>(null);
        }
        var visits = _healthCareData.patientVisitdata.Where(v => v.PatientId == patientId);
        var result = new PatientVisitDto
        {
            Patient = new PatientDto { PatientId = patient.Id, Name = patient.Name, Gender = patient.Gender.ToString() },
            Visits = visits.Select(o => new VisitDto
            {
                VisitId = o.VisitId,
                PractitionerId = o.PractitionerId,
                Date = o.Date,
                SlotTime = o.Slot.ToString(),
                Feedback = o.Feedback,
                Status = o.Status.ToString()
            }
            ).ToList()
        };
        return await Task.FromResult(result);
    }

    public async Task<PatientDto?> GetPatient(string patientId)
    {
        var result = _healthCareData.patients
            .Where(p => p.Id == patientId)
            .Select(p => new PatientDto
            {
                PatientId = p.Id,
                Name = p.Name,
                Gender = p.Gender.ToString()
            })
            .FirstOrDefault();

        return await Task.FromResult(result);
    }

    public async Task<PatientDto?> GetPatientFullDetails(string patientId)
    {
        var result = _healthCareData.patients
            .Where(p => p.Id == patientId)
            .Select(p => new PatientFullDetailDto
            {
                PatientId = p.Id,
                Name = p.Name,
                Gender = p.Gender.ToString(),
                Contact = new PatientContactDto
                {
                    Address = p.Address,
                    Email = p.Email,
                    Phone = p.Phone
                }
            })
            .FirstOrDefault();

        return await Task.FromResult(result);
    }

    public async Task<PractitionerDto?> GetPractioner(string practitionerId)
    {
        var result = _healthCareData.practioners
            .Where(p => p.Id == practitionerId)
            .Select(p => new PractitionerDto
            {
                PractitionerId = p.Id,
                Name = p.Name,
                Type = p.Type.ToString()
            })
            .FirstOrDefault();

        return await Task.FromResult(result);
    }

    public async Task<string> BookAppointment(
        string patientId, 
        string practitionerId,
        DateOnly date,
        (int hours,int minutes) startTime,
        (int hours,int minutes) endTime
    )
    {
        var visitId = Guid.NewGuid().ToString();
        _healthCareData.patientVisitdata.Add(new PatientVisit
        {
            VisitId = visitId,
            PatientId = patientId,
            PractitionerId = practitionerId,
            Date = date,
            Slot = new Slot 
            { 
                StartTime = new Time { Hours = startTime.hours, Minutes = startTime.minutes},
                EndTime = new Time { Hours = endTime.hours, Minutes = endTime.minutes}
            },
            Status = VisitStatus.Scheduled,
            Feedback = string.Empty,
            CreatedAt = DateTime.Now
        });

        return await Task.FromResult(visitId);
    }

    public async Task<IEnumerable<AllPatientVisitsDto>> GetAllVisitData()
    {
        var visits = _healthCareData.patientVisitdata.Select(o => new AllPatientVisitsDto
        {
                Patient = _healthCareData.patients.First(p=> p.Id == o.PatientId).ToPatientDto(),
                Practitioner = _healthCareData.practioners.First(p=> p.Id == o.PractitionerId).ToPractitionerDto(),
                VisitId = o.VisitId,
                PractitionerId = o.PractitionerId,
                Date = o.Date,
                SlotTime = o.Slot.ToString(),
                Feedback = o.Feedback,
                Status = o.Status.ToString(),
                CreatedAt = o.CreatedAt.ToString()
        });
        return await Task.FromResult(visits);
    }

    public async Task<IEnumerable<PatientDto>> GetAllPatients()
    {
        var patients = _healthCareData.patients.Select(p => new PatientDto
        {
            PatientId = p.Id,
            Name = p.Name,
            Gender = p.Gender.ToString()
        });

        return await Task.FromResult(patients);
    }

    public async Task<IEnumerable<PractitionerDto>> GetAllPractitioners()
    {
        var practioners = _healthCareData.practioners.Select(p => new PractitionerDto
        {
            PractitionerId = p.Id,
            Name = p.Name,
            Type = p.Type.ToString()
        });

        return await Task.FromResult(practioners);
    }
}