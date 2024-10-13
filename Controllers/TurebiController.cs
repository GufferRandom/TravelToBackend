using Microsoft.AspNetCore.Mvc;
using TravelToBackend.Interfaces;
using TravelToBackend.Data;
using TravelToBackend.Models;
using TravelToBackend.Dto;
using System.Collections.Generic;
using TravelToBackend.Repository;

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
    }
}
