using HMS.Model;

namespace HMS.Interface
{
    public interface IHospitalService
    {

        Task<Hospital> GetHospitalById(int Hospitalid);

        Task<Hospital> GetHospitalByName(string Hospitalname);

        Task<List<Hospital>> GetAllHospitals();
    }
}
