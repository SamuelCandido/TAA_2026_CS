using Problema01.LivrariaFrete.Models;

namespace Problema01.LivrariaFrete.TiposDeEntrega
{
    internal class RetiradaLocal : ITipoDeEntrega
    {
        private const decimal VALOR_RETIRADA_LOCAL = 0.00m;

        public decimal CalcularValorEntrega(Peso peso)
        {
            return VALOR_RETIRADA_LOCAL;
        }
    }
}