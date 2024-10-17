using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public bool Turi_Exists(int id)
        {
            var exists = _context.Turebi.FirstOrDefault(x=>x.id == id);
            if (exists != null)
            {
                return true;
            }
            return false;
        }
        public bool Company_Exists_by_turi_id(int turi_id)
        {
            var exists = _context.Turebi.Include("Company").FirstOrDefault(x=>x.id==turi_id).Company;
            if (exists != null) {
                return true;
            }
            return false;
        }
       
        public CompanyDto Get_Company_by_turi(int turi_id)
        {
            return ToCompanyDto.ToCompanydto(_context.Turebi.Include("Company").FirstOrDefault(x=>x.id==turi_id).Company);

        }
        public TurebiDto Create_Turi(TurebiDto turebidto)
        {

         var turi=ToTurebiFromDto.ToTurebi(turebidto);
            if (!Company_exists_by_company_id(turi.Company_Id)){
                turi.Company_Id = 1;
            }
         _context.Add(turi);
         _context.SaveChanges();
            return turebidto;
        }
        public bool Update_Turi(int id, TurebiDto value)
        {
            var turi = _context.Turebi.FirstOrDefault(x=>x.id==id);
            if (turi == null) { return false; }
            turi.Name = value.Name;
            turi.Price = value.Price;
            turi.image_name= value.image_name;
            if (Company_exists_by_company_id(value.Company_Id))
            {
                turi.Company_Id = value.Company_Id;

            }
            turi.Description = value.Description;
            _context.Update(turi);
            _context.SaveChanges();
            return true;
        }
        public void Delete_Turi(int id)
        {
           var turi = _context.Turebi.FirstOrDefault(x=>x.id==id);
            _context.Remove(turi);
            _context.SaveChanges();
        }

		public bool Turi_Exists_By_Name(string name)
		{
			var turi = _context.Turebi.FirstOrDefault(x=>x.Name==name);
            if (turi != null) {  return true; }
            return false;
		}

		public bool Turi_Exists_By_Object(TurebiDto turebi)
		{
			if(turebi.Company_Id == 0) { turebi.Company_Id = 1; }
			return _context.Turebi.Any(x => x.Name == turebi.Name && x.Price ==turebi.Price && x.Company_Id ==turebi.Company_Id);
		}

	}
}
