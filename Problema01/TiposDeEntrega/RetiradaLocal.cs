namespace Problema01.TiposDeEntrega
{
    internal class RetiradaLocal : ITipoDeEntrega
    {
        private const double ValorRetiradaLocal = 0.00;

        public double CalcularValorEntrega(double pesoTotalKg)
        {
            ValidadorDePeso.Validar(pesoTotalKg);

            return ValorRetiradaLocal;
        }
    }
}