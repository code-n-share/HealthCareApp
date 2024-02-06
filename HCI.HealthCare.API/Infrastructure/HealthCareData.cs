namespace HCI.HealthCare.API.Infrastructure;

public class HealthCareData
{
    public IList<Patient> patients;
    public IList<Practitioner> practioners;
    public IList<PatientVisit> patientVisitdata;
    public HealthCareData()
    {
        AddSeedData();
    }

    public void AddSeedData()
    {
        // Make sure PII data is stored in encrypted form in database when implemented
        patients = new List<Patient>
        {
            new Patient { Id = "10001", Name = "Patient1", Gender = Gender.Male, Address = "Add1", Email = "email1", Phone = "phone1"},
            new Patient { Id = "10002", Name = "Patient2", Gender = Gender.Female, Address = "Add2", Email = "email2", Phone = "phone2"},
            new Patient { Id = "10003", Name = "Patient3", Gender = Gender.Male, Address = "Add3", Email = "email3", Phone = "phone3"},
            new Patient { Id = "10004", Name = "Patient4", Gender = Gender.Female, Address = "Add4", Email = "email4", Phone = "phone4"},
            new Patient { Id = "10005", Name = "Patient5", Gender = Gender.Male, Address = "Add5", Email = "email5", Phone = "phone5"},
        };

        practioners = new List<Practitioner>
        {
            new Practitioner { Id = "00001", Name = "Practioner1", Type = PractionerType.GP},
            new Practitioner { Id = "00002", Name = "Practioner2", Type = PractionerType.Surgeon},
            new Practitioner { Id = "00003", Name = "Practioner3", Type = PractionerType.Radiologist},
            new Practitioner { Id = "00004", Name = "Practioner4", Type = PractionerType.Physiotherapist}
        };

        patientVisitdata = new List<PatientVisit>
        {
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10001" ,
                PractitionerId = "00001",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), 
                Slot = new Slot{ StartTime = new Time{ Hours = 15, Minutes = 15} , EndTime = new Time { Hours = 16 , Minutes = 0}},
                Feedback = string.Empty,
                Status = VisitStatus.Cancelled,
                CreatedAt = DateTime.Now.AddDays(-9)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10001" ,
                PractitionerId = "00002",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)),
                Slot = new Slot{ StartTime = new Time { Hours = 9 , Minutes = 0 } , EndTime = new Time { Hours = 9 , Minutes = 30}},
                Feedback = "some feedback 1",
                Status = VisitStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-8)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10002" ,
                PractitionerId = "00001",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
                Slot = new Slot{ StartTime = new Time { Hours = 12 , Minutes = 0} , EndTime = new Time { Hours = 13, Minutes = 0}},
                Feedback = string.Empty,
                Status = VisitStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-6)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10003" ,
                PractitionerId = "00004",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
                Slot = new Slot{ StartTime = new Time { Hours = 13 , Minutes = 0} , EndTime = new Time { Hours = 13, Minutes = 30}},
                Feedback = string.Empty,
                Status = VisitStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-6)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10002" ,
                PractitionerId = "00002",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)),
                Slot = new Slot{ StartTime = new Time { Hours = 13 , Minutes = 0} , EndTime = new Time { Hours = 13, Minutes = 30}},
                Feedback = string.Empty,
                Status = VisitStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-5)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10001" ,
                PractitionerId = "00002",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)),
                Slot = new Slot{ StartTime = new Time { Hours = 12 , Minutes = 0} , EndTime = new Time { Hours = 12, Minutes = 30}},
                Feedback = string.Empty,
                Status = VisitStatus.Cancelled,
                CreatedAt = DateTime.Now.AddDays(-5)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10001" ,
                PractitionerId = "00004",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                Slot = new Slot{ StartTime = new Time { Hours = 13 , Minutes = 0} , EndTime = new Time { Hours = 13, Minutes = 30}},
                Feedback = string.Empty,
                Status = VisitStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-4)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10005" ,
                PractitionerId = "00004",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                Slot = new Slot{ StartTime = new Time { Hours = 14 , Minutes = 0} , EndTime = new Time { Hours = 14, Minutes = 45}},
                Feedback = string.Empty,
                Status = VisitStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-3)
            },
            new PatientVisit
            {
                VisitId = Guid.NewGuid().ToString(),
                PatientId = "10002" ,
                PractitionerId = "00004",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                Slot = new Slot{ StartTime = new Time { Hours = 11 , Minutes = 0} , EndTime = new Time { Hours = 11, Minutes = 15}},
                Feedback = string.Empty,
                Status = VisitStatus.Scheduled,
                CreatedAt = DateTime.Now.AddDays(-1)
            }
        };
    }
}