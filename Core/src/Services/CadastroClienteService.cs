using Core.Dto;
using Core.Interfaces;
using Core.Model;
using Core.Model.Factories;

namespace Core.Services;

public class CadastroClienteService
{
    private readonly IClienteRepository clienteRepository;

    public CadastroClienteService(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
    }

    // public ServiceResponse<Cliente> ReativarClientePessoaFisica(PessoaFisica pessoaFisica)
    // {
    //     var novoCliente = ClienteFactory.FromPessoaFisica(pessoaFisica);
    //     return new ServiceResponse<Cliente>(clienteRepository.create(novoCliente));
    // }

    public ServiceResponse<Cliente> CadastrarNovoClientePessoaFisica(PessoaFisica pessoaFisica)
    {
        if (clienteRepository.VerificarCpfExiste(pessoaFisica.CPF))
        {
            return new ServiceResponse<Cliente>("CLIENTE_JA_CADASTRADO");
        }

        if (DateTime.Now.AddYears(-18).CompareTo(pessoaFisica.DataNascimento) < 0)
        {
            return new ServiceResponse<Cliente>("CLIENTE_DEVE_SER_MAIOR_18_ANOS");
        }

        if (string.IsNullOrEmpty(pessoaFisica.CPF))
        {
            return new ServiceResponse<Cliente>("CPF_OBRIGATORIO");
        }

        if (pessoaFisica.CPF.Length != 11)
        {
            return new ServiceResponse<Cliente>("TAMANHO_CPF_INCORRETO");
        }

        var novoCliente = ClienteFactory.FromPessoaFisica(pessoaFisica);

        return new ServiceResponse<Cliente>(clienteRepository.Create(novoCliente));
    }
}