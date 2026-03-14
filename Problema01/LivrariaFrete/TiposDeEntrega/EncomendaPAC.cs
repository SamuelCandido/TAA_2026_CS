
using Problema01.LivrariaFrete.Models;

namespace Problema01.LivrariaFrete.TiposDeEntrega
{
    internal class EncomendaPAC : ITipoDeEntrega
    {
        private const decimal PESO_MAXIMO_KG = 2.0m;
        private const decimal PESO_MAXIMO_LEVE_KG = 1.0m;
        private const decimal VALOR_PESO_LEVE = 10.00m;
        private const decimal VALOR_PESO_PESADO = 15.00m;

        public decimal CalcularValorEntrega(Peso peso)
        {
            if (peso.EmQuilogramas > PESO_MAXIMO_KG)
                throw new ArgumentOutOfRangeException(nameof(peso));

            if (peso.EmQuilogramas <= PESO_MAXIMO_LEVE_KG) 
                return VALOR_PESO_LEVE;

            return VALOR_PESO_PESADO;
        }
    }
}