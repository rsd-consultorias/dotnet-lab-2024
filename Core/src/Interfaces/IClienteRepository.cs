using Core.Model;

namespace Core.Interfaces;

public interface IClienteRepository {
    
    Cliente Create(Cliente novoCliente);
    Cliente BuscarPorId(Guid Id);

    Boolean VerificarCpfExistente(String cpf);
}