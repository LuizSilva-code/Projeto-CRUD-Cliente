using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarCPFStrategy
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidarCPFStrategy(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public void Validar(string cpf)
        {
            // Limpa o CPF caracteres especiais (caso haja)
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {
                throw new Exception("O CPF deve conter 11 dígitos.");
            }

            // Verifica sedigitos são iguais
            if (cpf.All(c => c == cpf[0]))
            {
                throw new Exception("CPF inválido: sequência de dígitos repetidos.");
            }

            //primeiro dígito do CPF
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
            {
                throw new Exception("CPF inválido: primeiro dígito verificador não confere.");
            }

            // segundo dígito do CPF
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
            {
                throw new Exception("CPF inválido: segundo dígito verificador não confere.");
            }
        }
    }
}
