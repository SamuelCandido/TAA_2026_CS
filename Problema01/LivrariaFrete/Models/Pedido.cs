using Problema01.LivrariaFrete.Enums;

namespace Problema01.LivrariaFrete.Models
{
    public class Pedido
    {
        private readonly List<Produto> _produtos = new();

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public Peso PesoTotal()
        {
            decimal totalGramas = 0;

            foreach (var produto in _produtos)
                totalGramas += produto.Peso.EmGramas;

            return new Peso(totalGramas, UnidadeDePesoEnum.GRAMA);
        }

    }
}