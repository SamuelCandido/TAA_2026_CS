namespace Problema01.TiposDeEntrega
{
    internal class EncomendaPAC : ITipoDeEntrega
    {
        private const decimal PesoMaximoKg = 2.0m;
        private const decimal PesoLimiteLeveKg = 1.0m;
        private const decimal ValorPesoLeve = 10.00m;
        private const decimal ValorPesoPesado = 15.00m;

        public decimal CalcularValorEntrega(Peso peso)
        {
            if (peso.EmQuilogramas > PesoMaximoKg)
                throw new ArgumentOutOfRangeException(nameof(peso));

            if (peso.EmQuilogramas <= PesoLimiteLeveKg) return ValorPesoLeve;

            return ValorPesoPesado;
        }
    }
}