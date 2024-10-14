using TravelToBackend.Dto;
using TravelToBackend.Models;
namespace TravelToBackend.Interfaces
{
    public interface ITurebiIepository
    {
        List<TurebiDto> GetAll();
        TurebiDto Get_Turi(int id);
        CompanyDto Get_Company_by_turi(int turi_id);
        CompanyDto Get_Company_by_company_id(int company_id);
        List<CompanyDto> Get_All_Companies();
        Turebi Create(TurebiDto turebi);
        void Update(int id, TurebiDto value);
        void Delete(int id);
    } 
}
