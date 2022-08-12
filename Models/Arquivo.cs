using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caceis_aws_api.Models
{
    [Table("Arquivo")]
    public class Arquivo
    {
        public int id { get; set; }

        public string nome { get; set; }

        public bool permitida { get;  set; }
    }
}
