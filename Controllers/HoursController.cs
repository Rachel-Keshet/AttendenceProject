using AttendenceP.Models;
using AutoMapper;
using Core;
using Core.Dtos;
using Core.entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AttendenceP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HoursController : ControllerBase
    {
        private readonly IHourService _hourService;
        private readonly IMapper _mapper;
        private readonly ILogger<HoursController> _logger;

        public HoursController(IHourService hourService, IMapper mapper, ILogger<HoursController> logger)
        {
            _hourService = hourService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<HoursController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                _logger.LogInformation("GET request for all hours.");
                var listHours = await _hourService.GetListAsync();
                var listDto = _mapper.Map<IEnumerable<HourDto>>(listHours);
                _logger.LogInformation("Successfully retrieved all hours.");
                return Ok(listDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving hours.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET api/<HoursController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int UserId)
        {
            try
            {
                _logger.LogInformation("GET request for hours with UserId: {UserId}", UserId);
                var hour = await _hourService.GetByIdAsync(UserId);
                if (hour == null)
                {
                    _logger.LogWarning("Hour record with UserId: {UserId} not found.", UserId);
                    return NotFound();
                }
                var hourDto = _mapper.Map<HourDto>(hour);
                _logger.LogInformation("Successfully retrieved hour for UserId: {UserId}.", UserId);
                return Ok(hourDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving hour with UserId: {UserId}.", UserId);
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST api/<HoursController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] HourPostModel hour)
        {
            try
            {
                _logger.LogInformation("POST request to add a new hour entry.");
                var hourToAdd = new Hour
                {
                    Id = hour.Id,
                    AttendDate = hour.AttendDate,
                    StartTime = hour.StartTime,
                    EndTime = hour.EndTime,
                    UserId = hour.UserId
                };

                var newHour = await _hourService.AddAsync(hourToAdd);
                _logger.LogInformation("Successfully added new hour entry with ID: {Id}.", newHour.Id);
                return Ok(newHour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new hour entry.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT api/<HoursController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] HourPostModel hour)
        {
            try
            {
                _logger.LogInformation("PUT request to update hour entry with ID: {Id}", id);
                var hourToUpdate = new Hour
                {
                    Id = hour.Id,
                    AttendDate = hour.AttendDate,
                    StartTime = hour.StartTime,
                    EndTime = hour.EndTime,
                    UserId = hour.UserId
                };

                var updatedHour = await _hourService.UpdateAsync(hourToUpdate);
                _logger.LogInformation("Successfully updated hour entry with ID: {Id}.", updatedHour.Id);
                return Ok(updatedHour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating hour entry with ID: {Id}.", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE api/<HoursController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                _logger.LogInformation("DELETE request to remove hour entry with ID: {Id}", id);
                await _hourService.DeleteAsync(id);
                _logger.LogInformation("Successfully deleted hour entry with ID: {Id}.", id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting hour entry with ID: {Id}.", id);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
