namespace Backend.Models
{
    public class PessoaUpdateModel
    {
        public int CPF { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string UltimoNome { get; set; }
        public int EnderecoId { get; set; }
    }
}
