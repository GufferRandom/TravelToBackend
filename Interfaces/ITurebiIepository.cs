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
     
        bool Company_Exists_by_turi_id(int turi_id);
        CompanyDto Get_Company_by_turi(int turi_id);
     
        TurebiDto Create_Turi(TurebiDto turebi);
        bool Update_Turi(int id, TurebiDto value);
        void Delete_Turi(int id);
      

    } 
}
