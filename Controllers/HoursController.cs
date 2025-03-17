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
        private readonly IHourService _HourService;

        public HoursController(IHourService HourService)
        {
            _HourService = HourService;
        }

        // GET: api/<HoursController>
        [HttpGet]
        public ActionResult Get()
        {
            var Hours = _HourService.GetList();
            return Ok(Hours);
        }

        // GET api/<HoursController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int UserId)
        {
            var Hour = _HourService.GetById(UserId);
            return Ok(Hour);
        }

        // POST api/<HoursController>
        [HttpPost]
        public ActionResult Post([FromBody] Hour Hour)
        {
            var newHour = _HourService.Add(Hour);
            return Ok(newHour);
        }

        // PUT api/<HoursController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hour Hour)
        {
            var updatedHour = _HourService.Update(Hour);
            return Ok(updatedHour);
        }

        // DELETE api/<HoursController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _HourService.Delete(id);
            return Ok();
        }
    }
}