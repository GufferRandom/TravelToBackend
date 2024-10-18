using Microsoft.EntityFrameworkCore;
using TravelToBackend.Data;
using TravelToBackend.Dto;
using TravelToBackend.Interfaces;
using TravelToBackend.Mapper;
using TravelToBackend.Models;

namespace TravelToBackend.Repository
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly AppDataContext _context;
        public CompanyRepository(AppDataContext context)
        {
            _context = context;
        }

        public bool Company_exists_by_company_id(int? company_id)
        {

            var exists = _context.Turebi.FirstOrDefault(x => x.Company_Id == company_id);
            if (exists != null)
            {
                return true;
            }
            return false;
        }
        public List<CompanyDto> Get_All_Companies()
        {
            return _context.Companiebi.Select(x => ToCompanyDto.ToCompanydto(x)).ToList();
        }
        public CompanyDto Get_Company_by_company_id(int company_id)
        {
            return ToCompanyDto.ToCompanydto(_context.Companiebi.FirstOrDefault(x => x.Company_Id == company_id));
        }
        public CompanyDto Create_Company(CompanyDto company)
        {
            
        }

        public bool Delete(CompanyDto company)
        {
            throw new NotImplementedException();
        }
    }
}
