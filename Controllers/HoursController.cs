using AttendenceP.Models;
using AutoMapper;
using Core;
using Core.Dtos;
using Core.entities;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoursController : ControllerBase
    {
        private readonly IHourService _hourService;
        private readonly IMapper _mapper;

        public HoursController(IHourService hourService, IMapper mapper)
        {
            _hourService = hourService;
            _mapper = mapper;
        }

        // GET: api/<HoursController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var listHours = await _hourService.GetListAsync();
            var listDto = _mapper.Map<IEnumerable<HourDto>>(listHours);
            return Ok(listDto);
        }

        // GET api/<HoursController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int UserId)
        {
            var hour = await _hourService.GetByIdAsync(UserId);
            var hourDto = _mapper.Map<HourDto>(hour);
            return Ok(hourDto);
        }

        // POST api/<HoursController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] HourPostModel hour)
        {
            var hourToAdd = new Hour { Id = hour.Id, AttendDate = hour.AttendDate, StartTime = hour.StartTime, EndTime = hour.EndTime, UserId = hour.UserId };
            var newHour = await _hourService.AddAsync(hourToAdd);
            return Ok(newHour);
        }

        // PUT api/<HoursController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] HourPostModel hour)
        {
            var hourToUpdate= new Hour { Id = hour.Id, AttendDate = hour.AttendDate, StartTime = hour.StartTime, EndTime = hour.EndTime, UserId = hour.UserId };
            var updatedHour =await _hourService.UpdateAsync(hourToUpdate);
            return Ok(updatedHour);
        }

        // DELETE api/<HoursController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _hourService.DeleteAsync(id);
            return Ok();
        }
    }
}