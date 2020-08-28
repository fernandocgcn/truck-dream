using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckDream.Domain.Entities;
using TruckDream.Domain.Services;

namespace TruckDream.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ModelController : ControllerBase
    {
        private readonly Repository repository;

        public ModelController(Repository repository)
            => this.repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetAll()
        {
            try
            {
                var models = await repository.GetAsync<Model>();
                return Ok(models);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
