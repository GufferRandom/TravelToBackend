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
        public List<Company> Get_All_Companies()
        {
            throw new NotImplementedException();
        }
        public Company Get_Company_by_company_id(int company_id)
        {
            throw new NotImplementedException();
        }

        public Company Get_Company_by_turi(int turi_id)
        {
            throw new NotImplementedException();
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
