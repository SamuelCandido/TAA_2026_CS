using Problema01.LivrariaFrete.Enums;

namespace Problema01.LivrariaFrete.Models
{
    public class Peso
    {
        public decimal EmGramas { get; }
        public decimal EmQuilogramas => EmGramas / (decimal)UnidadeDePesoEnum.QUILOGRAMA;
        public decimal EmToneladas => EmGramas / (decimal)UnidadeDePesoEnum.TONELADA;

        public Peso(decimal valor, UnidadeDePesoEnum unidade)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "O peso deve ser maior que zero.");

            decimal gramas = valor * (decimal)unidade;
            EmGramas = Math.Round(gramas, 2);
        }
    }
}