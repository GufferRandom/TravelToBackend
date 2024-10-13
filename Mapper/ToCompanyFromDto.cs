using System.Runtime.CompilerServices;
using TravelToBackend.Dto;
using TravelToBackend.Models;

namespace TravelToBackend.Mapper
{
    public class ToCompanyFromDto
    {
        public static CompanyDto ToCompany(CompanyDto companydto)
        {
            return new CompanyDto() { Company_Id = companydto.Company_Id, description = companydto.description, Name = companydto.Name, owner = companydto.owner, img_name = companydto.img_name };
        }
    }
}
