using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class AcademiaUpdateModel
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}