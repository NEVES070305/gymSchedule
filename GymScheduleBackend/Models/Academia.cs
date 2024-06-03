    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Academia
    {
        [Key]
        [Column(TypeName = "char(14)")]
        public string Cnpj { get; set; }

        [Required]
        [ForeignKey("Pessoa")]
        public Pessoa Proprietario { get; set; }
        

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        [ForeignKey("Rede")]
        [Column(TypeName = "char(14)")]
        public string CnpjRede { get; set; }
        public Rede Rede { get; set; }
    }
