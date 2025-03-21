using AttendenceP.Models;
using AutoMapper;
using Core;
using Core.Dtos;
//using Core.Dtos;
using Core.entities;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreeSicksController : ControllerBase
    {
        private readonly IFreeSickService _FreeSickService;
        private readonly IMapper _mapper;

        public FreeSicksController(IFreeSickService FreeSickService, IMapper mapper)
        {
            _FreeSickService = FreeSickService;
            _mapper = mapper;
        }

        // GET: api/<FreeSicksController>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        { 

            var freeSick =await _FreeSickService.GetListAsync();
            var listDto = _mapper.Map<IEnumerable<FreeSickDto>>(freeSick);
            return Ok(listDto);
        }

        // GET api/<FreeSicksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var freeSick = await _FreeSickService.GetByIdAsync(id);
            var freeSickDto = _mapper.Map<FreeSickDto>(freeSick);
            return Ok(freeSickDto);
        }

        // POST api/<FreeSicksController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] FreeSickPostModel FreeSick)
        {
            var FreeSickToAdd = new FreeSick { Id= FreeSick.Id, DayType = FreeSick.DayType, FreeDate = FreeSick.FreeDate, IsApproved= FreeSick.IsApproved, UserId= FreeSick.UserId };
            var newFreeSick = await _FreeSickService.AddAsync(FreeSickToAdd);
            return Ok(newFreeSick);
        }

        // PUT api/<FreeSicksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] FreeSickPostModel FreeSick)
        {
            var FreeSickToUpdate = new FreeSick { Id = FreeSick.Id, DayType = FreeSick.DayType, FreeDate = FreeSick.FreeDate, IsApproved = FreeSick.IsApproved, UserId = FreeSick.UserId };
            var updatedFreeSick = await _FreeSickService.UpdateAsync(FreeSickToUpdate);
            return Ok(updatedFreeSick);
        }

        // DELETE api/<FreeSicksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _FreeSickService.DeleteAsync(id);
            return Ok();
        }
    }
}

