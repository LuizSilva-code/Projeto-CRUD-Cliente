using CrudCliente.Applications.DTO;
using CrudCliente.Domain.Entities;
using CrudCliente.Infra.Repository.Cliente;
using System.Text.RegularExpressions;

namespace CrudCliente.Applications.Strategy.Validators
{
    public class ValidarSenhaForteStrategy
    {
        public void Validar(string senha)
        {
            if (string.IsNullOrEmpty(senha) || senha.Length < 8)
            {
                throw new Exception("A senha deve ter pelo menos 8 caracteres.");
            }

            if (!Regex.IsMatch(senha, "[a-z]"))
            {
                throw new Exception("A senha deve conter pelo menos uma letra minúscula.");
            }

            if (!Regex.IsMatch(senha, "[A-Z]"))
            {
                throw new Exception("A senha deve conter pelo menos uma letra maiúscula.");
            }

            if (!Regex.IsMatch(senha, "[^a-zA-Z0-9]"))
            {
                throw new Exception("A senha deve conter pelo menos um caractere especial.");
            }
        }
    }
}
