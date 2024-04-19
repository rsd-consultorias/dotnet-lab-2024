using API.Controllers;
using Core.Dto;
using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tests;

public class Tests
{
    private CadastroClienteService cadastroClienteService;
    private CadastrosController cadastrosController;

    [SetUp]
    public void Setup()
    {
        var clienteRepository = new ClienteFactory();
        cadastroClienteService = new CadastroClienteService(clienteRepository);

        cadastrosController = new CadastrosController(clienteRepository);
    }

    [Test]
    [Order(1)]
    public async Task TestEndpoints_CadastroClienteNovo()
    {
        var pessoaFisica = new PessoaFisica();
        pessoaFisica.Nome = "Fulano de Tal";
        pessoaFisica.CPF = "99999999999";
        pessoaFisica.DataNascimento = new DateTime(1984, 8, 8);

        var callApi = await cadastrosController.CadastrarNovoClientePessoaFisica(pessoaFisica);
        var novoCliente = (callApi.Result as OkObjectResult)?.Value as ServiceResponse<Cliente>;

        Assert.That(novoCliente?.Value, Is.Not.Null);
        
        callApi = await cadastrosController.CadastrarNovoClientePessoaFisica(pessoaFisica);
        var naoCriarCliente = (callApi.Result as OkObjectResult)?.Value as ServiceResponse<Cliente>;
        Assert.That(naoCriarCliente?.Error, Is.EqualTo("CLIENTE_JA_CADASTRADO"));
    }

    [Test]
    [Order(2)]
    public async Task TestEndpoints_CadastroClienteIncorretoAsync()
    {
        var pessoaFisica = new PessoaFisica();
        pessoaFisica.Nome = "Fulano de Tal";
        pessoaFisica.DataNascimento = new DateTime(DateTime.Now.Year - 17, 8, 8);

        var callApi = await cadastrosController.CadastrarNovoClientePessoaFisica(pessoaFisica);
        var naoCriarCliente = (callApi.Result as BadRequestObjectResult)?.Value as ServiceResponse<Cliente>;
        Assert.That(naoCriarCliente?.Error, Is.EqualTo("CLIENTE_DEVE_SER_MAIOR_18_ANOS"));

        pessoaFisica.DataNascimento = new DateTime(1984, 8, 8);
        
        callApi = await cadastrosController.CadastrarNovoClientePessoaFisica(pessoaFisica);
        naoCriarCliente = (callApi.Result as BadRequestObjectResult)?.Value as ServiceResponse<Cliente>;
        Assert.False(naoCriarCliente?.Success);
        Assert.That(naoCriarCliente?.Error, Is.EqualTo("CPF_OBRIGATORIO"));

        pessoaFisica.CPF = "9999999999";
        
        callApi = await cadastrosController.CadastrarNovoClientePessoaFisica(pessoaFisica);
        naoCriarCliente = (callApi.Result as BadRequestObjectResult)?.Value as ServiceResponse<Cliente>;
        Assert.False(naoCriarCliente?.Success);
        Assert.That(naoCriarCliente?.Error, Is.EqualTo("TAMANHO_CPF_INCORRETO"));
    }
}