using Domain.Validations;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }


        public Produto(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
            
            Validate(this, new ProdutoValidator());
        }
        
    }
}