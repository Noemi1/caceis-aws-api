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
    public class TipoConexaoController : ControllerBase
    {
        private const string V = "v1/tipoConexao/{tipoConexao.id}";
        private ModelDB db;
        public TipoConexaoController(ModelDB context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromServices] ModelDB context)
        {
            var tipoConexoes = await context.TipoConexao
                .AsNoTracking()
                .ToListAsync();
            return Ok(tipoConexoes);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ModelDB context, [FromRoute] int id)
        {
            var tipoConexao = await context.TipoConexao
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);

            if (tipoConexao == null)
            {
                return NotFound("Tipo de conexão não foi encontrada!");
            }
            return Ok(tipoConexao);


        }

        


    }
}
