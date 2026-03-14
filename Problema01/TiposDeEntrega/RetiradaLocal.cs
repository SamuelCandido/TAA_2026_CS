namespace Problema01.TiposDeEntrega
{
    internal class RetiradaLocal : ITipoDeEntrega
    {
        private const decimal ValorRetiradaLocal = 0.00m;

        public decimal CalcularValorEntrega(Peso peso)
        {
            return ValorRetiradaLocal;
        }
    }
}