using Microsoft.AspNetCore.Mvc;
using TravelToBackend.Interfaces;
using TravelToBackend.Data;
using TravelToBackend.Repository;
using TravelToBackend.Models;
using TravelToBackend.Dto;
namespace TravelToBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TurebiController:ControllerBase    {
        private readonly AppDataContext _context;
        private readonly ITurebiIepository _turebiIepository;
        public TurebiController(AppDataContext context, ITurebiIepository turebiIepository)
        {
            _context = context;
            _turebiIepository = turebiIepository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type=typeof(List<TurebiDto>))]
        [ProducesResponseType(404)]
        public IActionResult  get_turi()
        {
            var turi =_turebiIepository.GetAll();
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            return Ok(turi);
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(TurebiDto))]
        [ProducesResponseType(404)]
        public IActionResult Get_Turi_By_Id(int id) { 
        var turi= _turebiIepository.Get_Turi(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(turi);
        }
        [HttpGet("company/{turi_id}")]
        [ProducesResponseType(200, Type = typeof(CompanyDto))]
        [ProducesResponseType(400)]
        public IActionResult get_company_by_turi([FromRoute] int turi_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_turebiIepository.Get_Company_by_turi(turi_id));

        }
        
    }
}
