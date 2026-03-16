using Problema01.LivrariaFrete.Models;

namespace Problema01.LivrariaFrete.TiposDeEntrega
{
    internal class Sedex : ITipoDeEntrega
    {
        private const decimal PESO_MINIMO_KG = 0.5m;
        private const decimal PESO_MAXIMO_LEVE_KG = 1.0m;
        private const decimal VALOR_PESO_MINIMO = 12.50m;
        private const decimal VALOR_PESO_LEVE = 20.00m;
        private const decimal VALOR_BASE_PESO_PESADO = 46.50m;
        private const decimal VALOR_BLOCO_ADICIONAL = 1.50m;
        private const decimal PESO_BLOCO_GRAMAS = 100.0m;

        public decimal CalcularValorEntrega(Peso peso)
        {
            if (peso.EmQuilogramas <= PESO_MINIMO_KG) 
                return VALOR_PESO_MINIMO;

            if (peso.EmQuilogramas <= PESO_MAXIMO_LEVE_KG) 
                return VALOR_PESO_LEVE;

            decimal pesoAdicionalGramas = peso.EmGramas - (PESO_MAXIMO_LEVE_KG * 1000.0m);
            
            decimal blocosAdicionais = Math.Ceiling(pesoAdicionalGramas / PESO_BLOCO_GRAMAS);

            return VALOR_BASE_PESO_PESADO + (blocosAdicionais * VALOR_BLOCO_ADICIONAL);
        }
    }
}