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

        public bool PossuiProdutos() => _produtos.Count > 0;

        public Peso PesoTotal()
        {
            if (!PossuiProdutos())
                throw new InvalidOperationException("O pedido não possui produtos.");

            decimal totalGramas = _produtos.Sum(p => p.Peso.EmGramas);

            return new Peso(totalGramas, UnidadeDePesoEnum.GRAMA);
        }
    }
}