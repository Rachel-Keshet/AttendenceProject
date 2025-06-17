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
    public class FreeSicksController : ControllerBase
    {
        private readonly IFreeSickService _FreeSickService;
        private readonly IMapper _mapper;
        private readonly ILogger<FreeSicksController> _logger;

        public FreeSicksController(IFreeSickService FreeSickService, IMapper mapper, ILogger<FreeSicksController> logger)
        {
            _FreeSickService = FreeSickService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/<FreeSicksController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                _logger.LogInformation("GET request for all free sick days.");
                var freeSick = await _FreeSickService.GetListAsync();
                var listDto = _mapper.Map<IEnumerable<FreeSickDto>>(freeSick);
                _logger.LogInformation("Successfully retrieved free sick days.");
                return Ok(listDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving free sick days.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET api/<FreeSicksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            try
            {
                _logger.LogInformation("GET request for free sick day with ID: {Id}", id);
                var freeSick = await _FreeSickService.GetByIdAsync(id);
                if (freeSick == null)
                {
                    _logger.LogWarning("Free sick day with ID: {Id} not found.", id);
                    return NotFound();
                }
                var freeSickDto = _mapper.Map<FreeSickDto>(freeSick);
                _logger.LogInformation("Successfully retrieved free sick day with ID: {Id}.", id);
                return Ok(freeSickDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving free sick day with ID: {Id}.", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST api/<FreeSicksController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] FreeSickPostModel FreeSick)
        {
            try
            {
                _logger.LogInformation("POST request to add a new free sick day.");
                var FreeSickToAdd = new FreeSick
                {
                    Id = FreeSick.Id,
                    DayType = FreeSick.DayType,
                    FreeDate = FreeSick.FreeDate,
                    IsApproved = FreeSick.IsApproved,
                    UserId = FreeSick.UserId
                };

                var newFreeSick = await _FreeSickService.AddAsync(FreeSickToAdd);
                _logger.LogInformation("Successfully added a new free sick day with ID: {Id}.", newFreeSick.Id);
                return Ok(newFreeSick);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new free sick day.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT api/<FreeSicksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] FreeSickPostModel FreeSick)
        {
            try
            {
                _logger.LogInformation("PUT request to update free sick day with ID: {Id}", id);
                var FreeSickToUpdate = new FreeSick
                {
                    Id = FreeSick.Id,
                    DayType = FreeSick.DayType,
                    FreeDate = FreeSick.FreeDate,
                    IsApproved = FreeSick.IsApproved,
                    UserId = FreeSick.UserId
                };

                var updatedFreeSick = await _FreeSickService.UpdateAsync(FreeSickToUpdate);
                _logger.LogInformation("Successfully updated free sick day with ID: {Id}.", updatedFreeSick.Id);
                return Ok(updatedFreeSick);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating free sick day with ID: {Id}.", id);
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE api/<FreeSicksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DELETE request to remove free sick day with ID: {Id}", id);
                await _FreeSickService.DeleteAsync(id);
                _logger.LogInformation("Successfully deleted free sick day with ID: {Id}.", id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting free sick day with ID: {Id}.", id);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
