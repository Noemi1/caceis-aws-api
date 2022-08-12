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

    public class RedController : ControllerBase
    {
        private const string V = "v1/red/{red.id}";
        private ModelDB db;
        public RedController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] ModelDB context)
        {
            var red = await context.Red
                .AsNoTracking()
                .ToListAsync();
            return Ok(red);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ModelDB context, [FromRoute] int id)
        {
            var red = await context.Red
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (red == null)
            {
                return NotFound("Arquivo redirecionamento não foi encontrado!");
            }
            return Ok(red);


        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] ModelDB context,
           [FromBody] Red model
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await context.Red.AddAsync(model);
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
           [FromBody] Red model,
           [FromRoute] int id
            )
        {

            var red = await context.Red.FirstOrDefaultAsync(x => x.id == id);
            if (red == null)
                return NotFound("Arquivo parceiros não foi encontrado!");

            try
            {
                context.Red.Update(red);
                await context.SaveChangesAsync();

                return Ok(red);
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
            var red = await context.Parceiros.FirstOrDefaultAsync(x => x.id == id);
            if (red == null)
                return NotFound("Arquivo parceiros não foi encontrado!");
            try
            {
                context.Parceiros.Remove(red);
                await context.SaveChangesAsync();

                return Ok(red);
            }

            catch (Exception e)
            {
                return BadRequest(e);


            }
        }




    }
}

