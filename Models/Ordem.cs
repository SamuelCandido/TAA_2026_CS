using BolsaValores.Enums;

namespace BolsaValores.Models
{
    public class Ordem
    {
        public Investidor Investidor { get; }
        public TipoOrdemEnum Tipo { get; }
        public decimal Valor { get; }

        public Ordem(Investidor investidor, TipoOrdemEnum tipo, decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "O valor da ordem deve ser maior que zero.");

            Investidor = investidor ?? throw new ArgumentNullException(nameof(investidor));
            Tipo = tipo;
            Valor = valor;
        }
    }
}