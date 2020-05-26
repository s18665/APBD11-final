using System;
using System.Linq;
using APBD11.Entities;

namespace APBD11.Services
{
    public class MsSqlService : IDoctorDbService
    {
        private readonly DoctorDbContext _doctorDbContext;

        public MsSqlService(DoctorDbContext doctorDbContext)
        {
            _doctorDbContext = doctorDbContext;
            _doctorDbContext.Doctors.Add(new Doctor()
            {
                FirstName = "Johnny",
                LastName = "Sins",
                Email = "johnny@sins.com"
            });
            _doctorDbContext.Doctors.Add(new Doctor()
            {
                FirstName = "Jack",
                LastName = "Sparrow",
                Email = "uknown@test.com"
            });
            _doctorDbContext.Medicaments.Add(new Medicament()
            {
                Name = "Apap",
                Description = "Headache",
                Type = "Painkiller"
            });
            _doctorDbContext.Medicaments.Add(new Medicament()
            {
                Name = "Ibuprom",
                Description = "Headache",
                Type = "Painkiller"
            });
            _doctorDbContext.Patients.Add(new Patient()
            {
                FirstName = "Jacob",
                LastName = "Smith",
                BirthDate = DateTime.Parse("2000-10-10")
            });
            _doctorDbContext.Patients.Add(new Patient()
            {
                FirstName = "Ahmad",
                LastName = "Opx",
                BirthDate = DateTime.Parse("2010-02-11")
            });
            _doctorDbContext.Prescriptions.Add(new Prescription()
            {
                Date = DateTime.Parse("2000-10-10"),
                DueDate = DateTime.Today,
                IdDoctor = 1,
                IdPatient = 1
            });
            _doctorDbContext.Prescriptions.Add(new Prescription()
            {
                Date = DateTime.Parse("2010-10-10"),
                DueDate = DateTime.Today,
                IdDoctor = 2,
                IdPatient = 2
            });
            _doctorDbContext.PrescriptionMedicament.Add(new PrescriptionMedicament()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Details = "2 times a day",
                Dose = 1
            });
            _doctorDbContext.PrescriptionMedicament.Add(new PrescriptionMedicament()
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Details = "3 times a day",
                Dose = 3
            });

            _doctorDbContext.SaveChanges();
        }
        
        public Doctor GetDoctor(int id)
        {
            return _doctorDbContext.Doctors.FirstOrDefault(d => d.IdDoctor == id);
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            _doctorDbContext.Doctors.Add(new Doctor()
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            });
            return _doctorDbContext.SaveChanges() == 1 ? doctor : null;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var result = _doctorDbContext.Doctors.FirstOrDefault(d => d.IdDoctor == doctor.IdDoctor);
            if (result == null)
            {
                return null;
            }

            result.FirstName = doctor.FirstName;
            result.LastName = doctor.LastName;
            result.Email = doctor.Email;

            return _doctorDbContext.SaveChanges() == 1 ? result : null;
        }

        public bool DeleteDoctor(int id)
        {
            var doctor = _doctorDbContext.Doctors.FirstOrDefault(d => d.IdDoctor == id);
            if (doctor == null)
            {
                return false;
            }

            _doctorDbContext.Doctors.Remove(doctor);

            return _doctorDbContext.SaveChanges() == 1;
        }
    }
}