using AgendaDeContactos.Proyecto.Data;
using AgendaDeContactos.Proyecto.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDeContactos.Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AgendaContext _agendaContext;
        public UserController(AgendaContext agendaContext)
        {
            _agendaContext= agendaContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok();
        }

        [HttpGet("{apellido}")]

        public IActionResult GetUserBySurname(string apellido)
        {
            return Ok(_agendaContext.Users.Where(x => x.LastName == apellido).ToList());
        }
        [HttpDelete]
        public IActionResult DeleteUser()
        {
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateUser(User userToUpdateDto)
        {
            
        }
    }
}
