using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public class TruckController : ControllerBase
    {
        private readonly Repository repository;

        public TruckController(Repository repository)
            => this.repository = repository ??
                throw new ArgumentNullException(nameof(repository));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAll()
        {
            try
            {
                var trucks = await repository.GetAsync<Truck>
                    (includeProperties: nameof(Truck.Model));
                return Ok(trucks);
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

        [HttpPost]
        public async Task<ActionResult<object>> Insert([FromBody] object truckJson)
        {
            try
            {
                var truck = JsonConvert.DeserializeObject<Truck>
                    (truckJson?.ToString());
                truck.Model = await repository.GetByIdAsync
                    <Model>(truck.Model.Id);
                repository.InsertAsync(truck);
                await repository.CommitAsync();
                return CreatedAtAction(nameof(GetAll), truck);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<object>> Update([FromBody] object truckJson)
        {
            try
            {
                var truck = JsonConvert.DeserializeObject<Truck>
                    (truckJson?.ToString());
                repository.Update(truck);
                await repository.CommitAsync();
                return Ok(truck);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                repository.DeleteById<Truck>(id);
                await repository.CommitAsync();
                return Ok();
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
