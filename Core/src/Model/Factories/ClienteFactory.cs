namespace Core.Model.Factories;

public sealed class ClienteFactory
{
    public static Cliente FromPessoaFisica(PessoaFisica pessoaFisica)
    {
        return new Cliente
        {
            Nome = pessoaFisica.Nome,
            CPF = pessoaFisica.CPF,
            DataNascimento = pessoaFisica.DataNascimento
        };
    }
}