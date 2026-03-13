namespace Problema01.TiposDeEntrega
{
    internal static class ValidadorDePeso
    {
        public static void Validar(double pesoTotalKg)
        {
            if (pesoTotalKg <= 0)
                throw new ArgumentOutOfRangeException(nameof(pesoTotalKg), "O peso deve ser maior que zero.");
        }
    }
}