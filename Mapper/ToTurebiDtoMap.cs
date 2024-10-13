using TravelToBackend.Dto;
using TravelToBackend.Models;
namespace TravelToBackend.Mapper
{
    public class ToTurebiDtoMap
    {
        

        public static TurebiDto ToTurebiDto(Turebi turebi)
        {

            return new TurebiDto() { id = turebi.id, Price = turebi.Price, Name = turebi.Name, Description = turebi.Description, image_name = turebi.image_name, Company_Id = turebi.Company_Id }; 
            
     
        }
    }
}
