namespace Problema01.TiposDeEntrega
{
    public readonly struct Peso
    {
        public decimal EmGramas { get; }
        public decimal EmQuilogramas => EmGramas / (decimal)UnidadeDePeso.QUILOGRAMA;
        public decimal EmToneladas => EmGramas / (decimal)UnidadeDePeso.TONELADA;

        public Peso(decimal valor, UnidadeDePeso unidade)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "O peso deve ser maior que zero.");

            if (!Enum.IsDefined(typeof(UnidadeDePeso), unidade))
                throw new ArgumentOutOfRangeException(nameof(unidade), "Unidade de peso não reconhecida.");

            decimal gramas = valor * (decimal)unidade;
            EmGramas = Math.Round(gramas, 2);
        }
    }

    public interface ITipoDeEntrega
    {
        decimal CalcularValorEntrega(Peso peso);
    }
}