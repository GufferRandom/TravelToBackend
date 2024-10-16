using Microsoft.AspNetCore.Mvc;
using TravelToBackend.Data;
using TravelToBackend.Dto;
using TravelToBackend.Interfaces;

namespace TravelToBackend.Controllers
{
	[ApiController]

	[Route("api/[controller]")]
    public class CompanyController:ControllerBase
    {
		private readonly AppDataContext _context;
		private readonly ITurebiIepository _turebiRepository;

		public CompanyController(AppDataContext context, ITurebiIepository turebiRepository)
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


	}
}
