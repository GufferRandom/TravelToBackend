using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using TravelToBackend.Data;
using TravelToBackend.Dto;
using TravelToBackend.Interfaces;
using TravelToBackend.Mapper;
using TravelToBackend.Models;
namespace TravelToBackend.Repository
{
    public class TurebiRepository : ITurebiIepository
    {
        private readonly AppDataContext _context;
        public TurebiRepository(AppDataContext context)
        {
            _context = context;
        }

        public List<TurebiDto> GetAll()
        {
            ;
            var turebidto = _context.Turebi.
                Select(x => ToTurebiDtoMap.ToTurebiDto(x)).ToList(); 
            return turebidto;

        }
        public TurebiDto Get_Turi(int id)
        {
            var turi = _context.Turebi.FirstOrDefault(x => x.id == id);
            return ToTurebiDtoMap.ToTurebiDto(turi);
        }
        public List<CompanyDto> Get_All_Companies()
        {
            return _context.Companiebi.Select(x=>ToCompanyDto.ToCompanydto(x)).ToList();
        }
        public CompanyDto Get_Company_by_company_id(int company_id)
        {
            return ToCompanyDto.ToCompanydto(_context.Companiebi.FirstOrDefault(x => x.Company_Id == company_id));
        }

        public CompanyDto Get_Company_by_turi(int turi_id)
        {
            return ToCompanyDto.ToCompanydto(_context.Turebi.Include("Company").FirstOrDefault(x=>x.id==turi_id).Company);

        }
        public void Create(Turebi turebi)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
       
      

       
        public void Update(int id, Turebi value)
        {
            throw new NotImplementedException();
        }

        void ITurebiIepository.Create(TurebiDto turebi)
        {
            throw new NotImplementedException();
        }

        void ITurebiIepository.Update(int id, TurebiDto value)
        {
            throw new NotImplementedException();
        }
    }
}
