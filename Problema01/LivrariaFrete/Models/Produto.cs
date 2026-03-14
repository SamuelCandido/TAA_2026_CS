namespace Problema01.LivrariaFrete.Models
{
    public class Produto
    {
        public string Nome { get; }
        public decimal Valor { get; }
        public Peso Peso { get; }

        public Produto(string nome, decimal valor, Peso peso)
        {
            Nome = nome;
            Valor = valor;
            Peso = peso;
        }

    }
}