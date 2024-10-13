using System.Runtime.CompilerServices;
using TravelToBackend.Dto;
using TravelToBackend.Models;

namespace TravelToBackend.Mapper
{
    public class ToCompanyDto
    {
        public static CompanyDto ToCompanydto(Company company)
        {
            return new CompanyDto() { Company_Id = company.Company_Id,description=company.description,Name=company.Name,owner=company.owner, img_name=company.img_name};
        }
    }
}
