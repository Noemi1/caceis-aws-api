using caceis_aws_api.Data;
using caceis_aws_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caceis_aws_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class MonitorController : ControllerBase
    {
        private const string V = "v1/parceiros/{parceiros.id}";
        private ModelDB db;
        public MonitorController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] ModelDB context)
        {
            var monitor = await context.Monitor
                .AsNoTracking()
                .ToListAsync();
            return Ok(monitor);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ModelDB context, [FromRoute] int id)
        {
            var monitor = await context.Monitor
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (monitor == null)
            {
                return NotFound("Arquivo monitor não foi encontrado!");
            }
            return Ok(monitor);


        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] ModelDB context,
           [FromBody] Monitor model
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await context.Monitor.AddAsync(model);
                await context.SaveChangesAsync();
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync([FromServices] ModelDB context,
           [FromBody] Monitor model,
           [FromRoute] int id
            )
        {

            var monitor = await context.Monitor.FirstOrDefaultAsync(x => x.id == id);
            if (monitor == null)
                return NotFound("Arquivo monitor não foi encontrado!");

            try
            {
                context.Monitor.Update(monitor);
                await context.SaveChangesAsync();

                return Ok(monitor);
            }

            catch (Exception e)
            {
                return BadRequest();


            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] ModelDB context,

           [FromRoute] int id
            )
        {
            var monitor = await context.Monitor.FirstOrDefaultAsync(x => x.id == id);
            if (monitor == null)
                return NotFound("Arquivo monitor não foi encontrado!");
            try
            {
                context.Monitor.Remove(monitor);
                await context.SaveChangesAsync();

                return Ok(monitor);
            }

            catch (Exception e)
            {
                return BadRequest(e);


            }
        }




    }
}