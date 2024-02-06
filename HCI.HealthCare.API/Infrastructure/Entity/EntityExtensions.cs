using HCI.HealthCare.API.Models;

namespace HCI.HealthCare.API.Infrastructure;

public static class EntityExtensions
    {
        public static PatientDto ToPatientDto(this Patient patient)
        {
            return new PatientDto
            {
                PatientId = patient.Id,
                Name = patient.Name,
                Gender = patient.Gender.ToString()
            };
        }

        public static PractitionerDto ToPractitionerDto(this Practitioner practitioner)
        {
            return new PractitionerDto
            {
                PractitionerId = practitioner.Id,
                Name = practitioner.Name,
                Type = practitioner.Type.ToString()
            };
        }
    }