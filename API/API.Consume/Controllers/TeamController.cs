using API.BusinessLayer.Service;
using API.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Consume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _team;

        public TeamController(ITeamService team)
        {
            this._team = team;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var value = _team.GetAllS();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult AddTeam(Team r)
        {
            _team.SInsert(r);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var v = _team.Getbyid(id);
            _team.SDelete(v);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditTeam(Team r)
        {
            _team.SUpdate(r);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var v =  _team.Getbyid(id);
            return Ok(v);
        }
    }
}
