using caceis_aws_api.Data;
using caceis_aws_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace caceis_aws_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ArquivoController : ControllerBase
    {
        private const string V = "v1/arquivo/{arquivo.id}";
        private ModelDB db;
        public ArquivoController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] ModelDB context)
        {
            var arquivos = await context.Arquivos
                .AsNoTracking()
                .ToListAsync();
            return Ok(arquivos);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ModelDB context, [FromRoute] int id)
        {
            var arquivos = await context.Arquivos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (arquivos == null)
            {
                return NotFound("Arquivos não foram encontrado!");
            }
            return Ok(arquivos);


        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromServices] ModelDB context,
           [FromBody] Arquivo model
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await context.Arquivos.AddAsync(model);
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
           [FromBody] Arquivo model,
           [FromRoute] int id
            )
        {

            var arquivos = await context.Parceiros.FirstOrDefaultAsync(x => x.id == id);
            if (arquivos == null)
                return NotFound("Arquivos não foram encontrado!");

            try
            {
                context.Parceiros.Update(arquivos);
                await context.SaveChangesAsync();

                return Ok(arquivos);
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
            var arquivos = await context.Arquivos.FirstOrDefaultAsync(x => x.id == id);
            if (arquivos == null)
                return NotFound("Arquivos não foram encontrado!");
            try
            {
                context.Arquivos.Remove(arquivos);
                await context.SaveChangesAsync();

                return Ok(arquivos);
            }

            catch (Exception e)
            {
                return BadRequest(e);


            }
        }




    }
}







