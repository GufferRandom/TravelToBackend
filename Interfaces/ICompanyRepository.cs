using TravelToBackend.Dto;
using TravelToBackend.Models;

namespace TravelToBackend.Interfaces
{
    public interface ICompanyRepository
    {
        List<CompanyDto> Get_All_Companies();

        CompanyDto Get_Company_by_company_id(int company_id);
        bool Delete(CompanyDto company);
        bool Company_exists_by_company_id(int? company_id);
        Company Create_Company(CompanyDto company);
    }
}
