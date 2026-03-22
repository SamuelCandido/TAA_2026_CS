using BolsaValores.Enums;

namespace BolsaValores.Models
{
    public class Ordem
    {
        public Investidor Investidor { get; }
        public TipoOrdem Tipo { get; }
        public Dinheiro Valor { get; }

        public Ordem(Investidor investidor, TipoOrdem tipo, Dinheiro valor)
        {
            Investidor = investidor ?? throw new ArgumentNullException(nameof(investidor));
            Valor = valor ?? throw new ArgumentNullException(nameof(valor));
            Tipo = tipo;
        }

        public bool EhCompativelCom(Ordem outra)
        {
            return TipoOposto(outra) && MesmoValor(outra);
        }

        private bool TipoOposto(Ordem outra) => Tipo != outra.Tipo;

        private bool MesmoValor(Ordem outra) => Valor.MesmoValor(outra.Valor);
    }
}
