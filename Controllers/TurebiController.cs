using Microsoft.AspNetCore.Mvc;
using TravelToBackend.Interfaces;
using TravelToBackend.Data;
using TravelToBackend.Models;
using TravelToBackend.Dto;
using System.Collections.Generic;
using TravelToBackend.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TravelToBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurebiController : ControllerBase
    {
        private readonly AppDataContext _context;
        private readonly ITurebiIepository _turebiRepository;

        public TurebiController(AppDataContext context, ITurebiIepository turebiRepository)
        {
            _context = context;
            _turebiRepository = turebiRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TurebiDto>))]
        [ProducesResponseType(404)]
        public IActionResult GetTuri()
        {
            var turi = _turebiRepository.GetAll();
            return Ok(turi);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TurebiDto))]
        [ProducesResponseType(404)]
        public IActionResult GetTuriById(int id)
        {
            var turi = _turebiRepository.Get_Turi(id);
            if (turi == null) return NotFound();
            return Ok(turi);
        }
        [HttpGet("/turi/exists/{turi_id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult turi_exists([FromRoute] int turi_id)
        {
            var exists = _turebiRepository.Turi_Exists(turi_id);
            if (!exists) return NotFound();
            return Ok(exists);
        }
        [HttpGet("/company/exists/{company_id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult company_exists([FromRoute] int company_id)
        {
            var exists = _turebiRepository.Company_Exists_by_turi_id(company_id);
            if (!exists) return NotFound();
            return Ok(exists);
        }
        [HttpGet("/company/exists/turi/{turi_id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult company_exists_by_turi_id([FromRoute] int turi_id)
        {
            var exists = _turebiRepository.Company_Exists_by_turi_id(turi_id);
            if (!exists) return NotFound();
            return Ok(exists);
        }
        [HttpGet("companies")]
        [ProducesResponseType(200, Type = typeof(List<CompanyDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllCompanies()
        {
            var companies = _turebiRepository.Get_All_Companies();
            return Ok(companies);
        }
        [HttpGet("companies/{companyId}")]
        [ProducesResponseType(200, Type = typeof(CompanyDto))]
        [ProducesResponseType(404)]
        public IActionResult GetCompanyById(int companyId)
        {
            var company = _turebiRepository.Get_Company_by_company_id(companyId);
            if (company == null) return NotFound();
            return Ok(company);
        }
        [HttpGet("companies/turi_id/{turiId}")]
        [ProducesResponseType(200, Type = typeof(CompanyDto))]
        [ProducesResponseType(404)]
        public IActionResult GetCompanyByTuri(int turiId)
        {
            var company = _turebiRepository.Get_Company_by_turi(turiId);
            if (company == null) return NotFound();
            return Ok(company);
        }
        [HttpPost("turi/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
		public IActionResult Create([FromBody] TurebiDto turebi)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState); 
			}

			if (_turebiRepository.Turi_Exists_By_Object(turebi))
			{
				return Conflict("The turi exists; please enter a different one."); 
			}

			var turi = _turebiRepository.Create_Turi(turebi);
			return Ok(turi);
		}

		[HttpPut("turi/update/{turi_id}")]
        [ProducesResponseType(200, Type = typeof(TurebiDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public IActionResult update_turi([FromRoute] int turi_id, [FromBody] TurebiDto turebi)
        {
            if (!ModelState.IsValid)
            {

                BadRequest(ModelState);
            }

            if (_turebiRepository.Update_Turi(turi_id, turebi) == false)
            {
                return NotFound();
            }
            _turebiRepository.Update_Turi(turi_id, turebi);

			return Ok("Turebi Was updated Successfuly");

        }
        [HttpDelete("turi/delete/{turi_id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult Delete_turi([FromRoute] int turi_id)
        {
            if (_turebiRepository.Turi_Exists(turi_id))
            {
                _turebiRepository.Delete_Turi(turi_id);
                return StatusCode(200,$"the turi  {turi_id} was Deleted Successfully");
            }
            return BadRequest();
            
        }
    }
}
