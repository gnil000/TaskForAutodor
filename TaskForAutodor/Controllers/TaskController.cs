using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using TaskForAutodor.Models;
using TaskForAutodor.Models.Repositories;

namespace TaskForAutodor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {

        [HttpPost]
        public IActionResult Tasks(RequestView reqv)
        {
            if (reqv.tasks < 3 || reqv.tasks > 25)
                return BadRequest("The number of tasks must be equal to or greater than 3 and equal to or less than 25");

            var result = FakeTask.GoTasks(reqv.tasks, reqv.parallel);

            return Ok(result);
        }
    }
}
