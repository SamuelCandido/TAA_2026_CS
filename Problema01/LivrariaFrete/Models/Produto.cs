namespace Problema01.LivrariaFrete.Models
{
    public class Produto
    {
        public string Nome { get; }
        public decimal Valor { get; }
        public Peso Peso { get; }

        public Produto(string nome, decimal valor, Peso peso)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto é obrigatório.", nameof(nome));

            if (valor < 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "Valor não pode ser negativo.");

            Nome = nome;
            Valor = valor;
            Peso = peso ?? throw new ArgumentNullException(nameof(peso));
        }
    }
}