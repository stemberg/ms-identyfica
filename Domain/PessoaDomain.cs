using IDentyfica.Data;
using IDentyfica.Model;
using System.Text.RegularExpressions;

namespace IDentyfica.Domain
{
    public class PessoaDomain
    {
        private readonly IDentyficaDbContext _context;

        public PessoaDomain(IDentyficaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pessoa> BuscarTodas()
        {
            var pessoas = _context.Pessoas.ToList();
            return pessoas;
        }

        public Pessoa AdicionarPessoa(Pessoa pessoa)
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);

            if (!VerificarMaiorIdade(dataAtual, pessoa.DataNascimento))
            {
                throw new Exception("A pessoa precisa ser maior de idade.");
            }
                
            if (!ValidarCPF(pessoa.Cpf))
            {
                throw new Exception("CPF inválido.");
            }

            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return pessoa;
        }

        public Pessoa BuscarPessoaPorId(Guid id)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);

            if (pessoa == null)
            {
                throw new Exception("Pessoa não encontrada.");
            }

            return pessoa;
        }

        public String RemoverPessoa(Guid id)
        {
            Pessoa pessoa = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);

            if (pessoa == null)
            {
                throw new Exception("Pessoa mão encontrada.");
            }

            _context.Remove(pessoa);
            _context.SaveChanges();

            return "Pessoa removida com sucesso!";
        }

        public Pessoa AtualizarPessoa(Guid id, Pessoa pessoa)
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);

            if (!VerificarMaiorIdade(dataAtual, pessoa.DataNascimento))
            {
                throw new Exception("A pessoa precisa ser maior de idade.");
            }

            if (!ValidarCPF(pessoa.Cpf))
            {
                throw new Exception("CPF inválido.");
            }

            Pessoa pessoaEncontrada = _context.Pessoas.FirstOrDefault(pessoa => pessoa.Id == id);

            if (pessoaEncontrada == null)
            {
                throw new Exception("Pessoa mão encontrada.");
            }

            pessoaEncontrada.Nome = pessoa.Nome;
            pessoaEncontrada.Cpf = pessoa.Cpf;
            pessoaEncontrada.DataNascimento = pessoa.DataNascimento;
            pessoaEncontrada.Endereco = pessoa.Endereco;    
            pessoaEncontrada.Sexo = pessoa.Sexo;    

            _context.SaveChanges();

            return pessoaEncontrada;
        }



        public static bool ValidarCPF(string cpf)
        {
            string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            return Regex.IsMatch(cpf, pattern);
        }

        public static bool VerificarMaiorIdade(DateOnly dataAtual, DateOnly dataNascimento)
        {
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataAtual.Month < dataNascimento.Month ||
                (dataAtual.Month == dataNascimento.Month && dataAtual.Day < dataNascimento.Day))
            {
                idade--;
            }

            return idade >= 18;
        }
    }
}
