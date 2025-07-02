namespace CrudCliente.Applications.Strategy
{
    public class CriptografarSenhaStrategy
    {
        public string CriptografarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
