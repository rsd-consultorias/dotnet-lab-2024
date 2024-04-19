using API.Infra.Repositories;
using Core.Dto;
using Core.Interfaces;
using Core.Model;
using Core.Services;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/cadastros/v1")]
public class CadastrosController : ControllerBase
{
    private readonly IClienteRepository clienteRepository;
    private CadastroClienteService cadastroClienteService;

    public CadastrosController(IClienteRepository clienteRepository)
    {
        this.clienteRepository = clienteRepository;
        cadastroClienteService = new CadastroClienteService(clienteRepository);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceResponse<Cliente>>> CadastrarNovoClientePessoaFisica(PessoaFisica pessoaFisica)
    {
        var novoCliente = cadastroClienteService.CadastrarNovoClientePessoaFisica(pessoaFisica);

        if (novoCliente.Success)
        {
            return Ok(novoCliente);
        }
        else
        {
            return BadRequest(novoCliente);
        }
    }

    [HttpGet("/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ServiceResponse<Cliente>>> BuscarNovoCliente(Guid id)
    {
        var cliente = clienteRepository.BuscarPorId(id);
        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }
}