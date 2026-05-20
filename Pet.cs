public class Pet
{
    public int Id {get; set;}
    public string? Especie {get; set;}
    public double Peso {get; set;}
    public bool Vivo {get; set;}
    public DateTime DataCadastro {get; set;} = DateTime.Now;

}