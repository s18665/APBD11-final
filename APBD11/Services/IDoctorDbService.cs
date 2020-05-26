using APBD11.Entities;

namespace APBD11.Services
{
    public interface IDoctorDbService
    {
        Doctor GetDoctor(int id);
        Doctor AddDoctor(Doctor doctor);
        Doctor UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int id);
    }
}