using caceis_aws_api.Data;
using caceis_aws_api.Models;
using caceis_aws_api.ViewModels;
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

        public class ParceirosController : ControllerBase
        {
            private const string V = "v1/parceiros/{parceiros.id}";
            private ModelDB db;
            public ParceirosController(ModelDB context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetAsync([FromServices] ModelDB context)
            {
                var parceiros = await context.Parceiros
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(parceiros);

            }

            [HttpGet]
            [Route("{id}")]
            public async Task<IActionResult> GetByIdAsync([FromServices] ModelDB context, [FromRoute] int id)
            {
                var parceiros = await context.Parceiros
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.id == id);

                if (parceiros == null)
                {
                    return NotFound("Arquivo parceiros não foi encontrado!");
                }
                return Ok(parceiros);


            }

            [HttpPost]
            public async Task<IActionResult> PostAsync([FromServices] ModelDB context,
               [FromBody] Parceiros model
                )
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                try
                {
                    await context.Parceiros.AddAsync(model);
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
               [FromBody] Parceiros model,
               [FromRoute] int id
                )
            {

                var parceiros = await context.Parceiros.FirstOrDefaultAsync(x => x.id == id);
                if (parceiros == null)
                    return NotFound("Arquivo parceiros não foi encontrado!");

                try
                {
                    context.Parceiros.Update(parceiros);
                    await context.SaveChangesAsync();

                    return Ok(parceiros);
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
                var parceiros = await context.Parceiros.FirstOrDefaultAsync(x => x.id == id);
                if (parceiros == null)
                    return NotFound("Arquivo parceiros não foi encontrado!");
                try
                {
                    context.Parceiros.Remove(parceiros);
                    await context.SaveChangesAsync();

                    return Ok(parceiros);
                }

                catch (Exception e)
                {
                    return BadRequest(e);


                }
            }




        }
    }







