using API.Infra.Database;
using Core.Interfaces;
using Core.Model;

namespace API.Infra.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ExemploDbContext dbContext;
    public ClienteRepository(ExemploDbContext context)
    {
        dbContext = context;
    }

    public Cliente BuscarPorId(Guid Id)
    {
        return dbContext.Clientes.FirstOrDefault()!;
    }

    public Cliente Create(Cliente novoCliente)
    {
        var clienteCriado = dbContext.Clientes.Add(novoCliente);
        dbContext.SaveChanges();
        return clienteCriado.Entity;
    }

    public bool VerificarCpfExiste(string cpf)
    {
        return dbContext.Clientes.Where(c => cpf.Equals(c.CPF)).Count() > 0;
    }
}