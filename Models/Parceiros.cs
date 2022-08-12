using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caceis_aws_api.Models
{

    public class Parceiros
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string codigo { get; set; }

        public int autenticacaoId { get; set; }

        public int conexaoId { get; set; }

        public string conexaoHost { get; set; }

        public string conexaoPorta { get; set; }

        public string usuario { get; set; }

        public string senha { get; set; }

        public string senhaPrivada { get; set; }

        public string chavePrivada { get; set; }

        public string dataDaCriacao { get; set; }

        public string dataDaAlteracao { get; set; }

        public string autenticacao { get; set; }

    }
}
    
    
    
    
 