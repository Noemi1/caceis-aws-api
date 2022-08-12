using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caceis_aws_api.Models
{
    
    public class Monitor
    {
        public int id { get; set; }
        public string transStatus { get; set; }
        public string tipoTransferencia { get;  set; }
        public string dataHoraInicia { get; set; }
        public string dataHoraFinal { get; set; }
        public string bucketOrigem { get; set; }
        public string bucketDestino { get; set; }
        public string nomeArquivo { get; set; }
        public string observacoes { get; set; }


    }
}

