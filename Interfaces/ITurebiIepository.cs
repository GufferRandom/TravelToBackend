using TravelToBackend.Dto;
using TravelToBackend.Models;
namespace TravelToBackend.Interfaces
{
    public interface ITurebiIepository
    {
        List<TurebiDto> GetAll();
        TurebiDto Get_Turi(int id);
        bool Turi_Exists(int id);
        bool Turi_Exists_By_Name(string name);
        bool Turi_Exists_By_Object(TurebiDto turebi);
        bool Company_exists_by_company_id(int? company_id);
        bool Company_Exists_by_turi_id(int turi_id);
        CompanyDto Get_Company_by_turi(int turi_id);
        CompanyDto Get_Company_by_company_id(int company_id);
        List<CompanyDto> Get_All_Companies();
        TurebiDto Create_Turi(TurebiDto turebi);
        bool Update_Turi(int id, TurebiDto value);
        void Delete_Turi(int id);
        Company Create_Company(CompanyDto company);

    } 
}
