namespace Core.Model;

public class Cliente : BaseModel
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
}
