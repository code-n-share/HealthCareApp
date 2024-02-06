using HCI.HealthCare.API.Exceptions;
using HCI.HealthCare.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HCI.HealthCare.API.Domain;

public class HealthCareService : IHealthCareService
{
    private readonly IHealthCareRepository _healthCareRepository;

    public HealthCareService(IHealthCareRepository healthCareRepository)
    {
        _healthCareRepository = healthCareRepository;
    }

    public async Task<PatientVisitDto?> GetPatientVisitInfo(string patientId)
    {
        return await _healthCareRepository.GetPatientVisit(patientId);
    }

    public async Task<string> BookAppointment(BookAppointmentDto bookAppointmentDto)
    {
        var patient = await _healthCareRepository.GetPatient(bookAppointmentDto.PatientId);
        if (patient == null) throw new PatientNotFoundException(bookAppointmentDto.PatientId);

        var practitioner = await _healthCareRepository.GetPractioner(bookAppointmentDto.PractitionerId);
        if (practitioner == null) throw new PractitionerNotFoundException(bookAppointmentDto.PractitionerId);

        var startTime = GetTimeIn24HrClock(bookAppointmentDto.SlotStartTime);
        var endTime = GetTimeIn24HrClock(bookAppointmentDto.SlotEndTime);

        return await _healthCareRepository.BookAppointment(
            patient.PatientId,
            practitioner.PractitionerId,
            DateOnly.FromDateTime(bookAppointmentDto.Date),
            startTime,
            endTime
            );

    }

    public (int, int) GetTimeIn24HrClock(string time)
    {
        var time1 = time.Trim().ToUpper();
        bool isPostMeridiem = time1.EndsWith("PM");
        string hourAndMinutes = isPostMeridiem ? time1.Replace("PM", "").Trim() : time1.Replace("AM", "").Trim();
        var arr = hourAndMinutes.Split(":");
        int hour = int.Parse(arr[0]);
        int minutes = int.Parse(arr[1]);
        if (isPostMeridiem && hour != 12)
        {
            return (hour + 12, minutes);
        }
        else
        {
            return (hour, minutes);
        }
    }

    public async Task<IEnumerable<AllPatientVisitsDto>> GetAllVisitData() =>
        await _healthCareRepository.GetAllVisitData();

    public async Task<IEnumerable<PatientDto?>> GetAllPatients() =>
        await _healthCareRepository.GetAllPatients();

    public async Task<IEnumerable<PractitionerDto>> GetAllPractitioners() =>
        await _healthCareRepository.GetAllPractitioners();
}