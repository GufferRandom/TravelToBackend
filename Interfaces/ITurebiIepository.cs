using TravelToBackend.Dto;
using TravelToBackend.Models;
namespace TravelToBackend.Interfaces
{
    public interface ITurebiIepository
    {
        List<TurebiDto> GetAll();
        TurebiDto Get_Turi(int id);
        Company Get_Company_by_turi(int turi_id);
        Company Get_Company_by_company_id(int company_id);
        List<Company> Get_All_Companies();
        void Create(TurebiDto turebi);
        void Update(int id, TurebiDto value);
        void Delete(int id);
    } 
}
