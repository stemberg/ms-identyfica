using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDentyfica.Model
{
    public class Pessoa
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nome_pessoa")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Column("cpf_pessoa")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string Cpf { get; set; }

        [Column("data_nascimento_pessoa")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateOnly DataNascimento { get; set; }

        [Column("endereco_pessoa")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string Endereco { get; set; }

        [Column("sexo_pessoa")]
        [Required(ErrorMessage = "O sexo é obrigatório.")]
        public string Sexo { get; set; }
    }
}
