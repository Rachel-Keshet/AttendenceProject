
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

        public FreeSicksController(IFreeSickService FreeSickService)
        {
            _FreeSickService = FreeSickService;
        }

        // GET: api/<FreeSicksController>
        [HttpGet]
        public ActionResult Get()
        {
            var FreeSicks = _FreeSickService.GetList();
            return Ok(FreeSicks);
        }

        // GET api/<FreeSicksController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var FreeSick = _FreeSickService.GetById(id);
            return Ok(FreeSick);
        }

        // POST api/<FreeSicksController>
        [HttpPost]
        public ActionResult Post([FromBody] FreeSick FreeSick)
        {
            var newFreeSick = _FreeSickService.Add(FreeSick);
            return Ok(newFreeSick);
        }

        // PUT api/<FreeSicksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] FreeSick FreeSick)
        {
            var updatedFreeSick = _FreeSickService.Update(FreeSick);
            return Ok(updatedFreeSick);
        }

        // DELETE api/<FreeSicksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _FreeSickService.Delete(id);
            return Ok();
        }
    }
}

