using AutoMapper;
using BookingCare.API.Services.DatabaseService;
using BookingCare.Shared.ModelDtos;
using Microsoft.AspNetCore.Mvc;

namespace BookingCare.API.Controllers
{
	[ApiController]
	[Route("api/booking")]
	public class BookingController: ControllerBase
	{
		private readonly IMapper m_Mapper;
		private readonly IDatabaseService m_DatabaseService;

		public BookingController(IMapper mapper, IDatabaseService databaseService)
		{
			m_Mapper = mapper;
			m_DatabaseService = databaseService;
		}

		[HttpGet("scheduletimes")]
		public async Task<ActionResult<List<ScheduleTimeDto>>> GetScheduleTimes()
		{
			var scheduleTimes = await m_DatabaseService.GetAllScheduleTimes();
			var scheduleTimeDtos = m_Mapper.Map<List<ScheduleTimeDto>>(scheduleTimes);
			return Ok(scheduleTimeDtos);
		}
	}
}
