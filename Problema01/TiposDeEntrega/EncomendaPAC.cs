namespace Problema01.TiposDeEntrega
{
    internal class EncomendaPAC : ITipoDeEntrega
    {
        private const double PesoMaximoKg = 2.0;
        private const double PesoLimiteLeveKg = 1.0;
        private const double ValorPesoLeve = 10.00;
        private const double ValorPesoPesado = 15.00;

        public double CalcularValorEntrega(double pesoTotalKg)
        {
            ValidadorDePeso.Validar(pesoTotalKg);

            if (pesoTotalKg > PesoMaximoKg)
                throw new ArgumentOutOfRangeException(nameof(pesoTotalKg), "PAC aceita apenas pedidos até 2kg.");

            if (pesoTotalKg <= PesoLimiteLeveKg) return ValorPesoLeve;

            return ValorPesoPesado;
        }
    }
}