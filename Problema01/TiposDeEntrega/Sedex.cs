namespace Problema01.TiposDeEntrega
{
    internal class Sedex : ITipoDeEntrega
    {
        private const decimal PesoLimiteMinimoKg = 0.5m;
        private const decimal PesoLimiteLeveKg = 1.0m;
        private const decimal ValorPesoMinimo = 12.50m;
        private const decimal ValorPesoLeve = 20.00m;
        private const decimal ValorBase = 46.50m;
        private const decimal ValorPorBlocoAdicional = 1.50m;
        private const decimal GramasPorBloco = 100.0m;

        public decimal CalcularValorEntrega(Peso peso)
        {
            if (peso.EmQuilogramas <= PesoLimiteMinimoKg) return ValorPesoMinimo;
            if (peso.EmQuilogramas <= PesoLimiteLeveKg) return ValorPesoLeve;

            decimal pesoAdicionalGramas = peso.EmGramas - (PesoLimiteLeveKg * 1000.0m);
            decimal blocosAdicionais = Math.Ceiling(pesoAdicionalGramas / GramasPorBloco);

            return ValorBase + (blocosAdicionais * ValorPorBlocoAdicional);
        }
    }
}