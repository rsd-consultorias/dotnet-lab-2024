namespace Core.Model;

public class PessoaFisica : BaseModel
{
    public string CPF { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
}