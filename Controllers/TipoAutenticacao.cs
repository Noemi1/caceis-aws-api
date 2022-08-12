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

    public class TipoAutenticacaoController : ControllerBase
    {
        private const string V = "v1/parceiros/{parceiros.id}";
        private ModelDB db;
        public TipoAutenticacaoController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] ModelDB context)
         {
            var tipoAutenticacao = await context.TipoAutenticacao
                .AsNoTracking()
                .ToListAsync();
            return Ok(tipoAutenticacao);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ModelDB context, [FromRoute] int id)
        {
            var tipoAutenticacao = await context.TipoAutenticacao
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (tipoAutenticacao == null)
            {
                return NotFound("Arquivo Tipo de Autenticação não foi encontrado!");
            }
            return Ok(tipoAutenticacao);


        }

        



    }
}






