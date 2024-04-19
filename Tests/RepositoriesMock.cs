using Core.Interfaces;
using Core.Model;

namespace Tests;

public class ClienteFactory : IClienteRepository
{
    private Dictionary<Guid, Cliente> clientes = new Dictionary<Guid, Cliente>();

    public Cliente BuscarPorId(Guid id)
    {
        return clientes[id];
    }

    public Cliente Create(Cliente novoCliente)
    {
        novoCliente.Id = Guid.NewGuid();
        clientes.Add(novoCliente.Id, novoCliente);

        return clientes[novoCliente.Id];
    }

    public bool VerificarCpfExiste(string cpf)
    {
        return clientes.Where(c => cpf.Equals(c.Value.CPF)).Count() > 0;
    }
}