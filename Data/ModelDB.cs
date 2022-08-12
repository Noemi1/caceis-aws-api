using caceis_aws_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caceis_aws_api.Data
{
    public class ModelDB: DbContext
    {
        public DbSet<Arquivo> Arquivos { get; set;}
        public DbSet<TipoConexao> TipoConexao { get; set; }

        public DbSet<TipoAutenticacao> TipoAutenticacao { get; set; }

        public DbSet<Red> Red { get; set; }

        public DbSet<Parceiros> Parceiros { get; set; }

        public DbSet<Monitor> Monitor { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HVURGOU;Initial Catalog=caceis-aws;Integrated Security=True");
        }
    }
}
