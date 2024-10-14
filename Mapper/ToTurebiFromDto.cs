using TravelToBackend.Dto;
using TravelToBackend.Models;

namespace TravelToBackend.Mapper
{
    public class ToTurebiFromDto
    {
            public static Turebi ToTurebi(TurebiDto turebidto)
            {

            return new Turebi()
            {
                Price = turebidto.Price,
                Name = turebidto.Name,
                Description = turebidto.Description,
                image_name = turebidto.image_name,
                Company_Id = turebidto.Company_Id,
                
            };

    }

}
}
