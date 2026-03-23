using BolsaValores.Enums;

namespace BolsaValores.Models
{
    public class OrdemProgramada
    {
        public Acao Acao { get; }
        public Dinheiro ValorGatilho { get; }
        public TipoOrdem TipoOrdem { get; }
        public Dinheiro ValorOrdem { get; }

        public OrdemProgramada(Acao acao, Dinheiro valorGatilho, TipoOrdem tipoOrdem, Dinheiro valorOrdem)
        {
            Acao = acao ?? throw new ArgumentNullException(nameof(acao));
            ValorGatilho = valorGatilho ?? throw new ArgumentNullException(nameof(valorGatilho));
            ValorOrdem = valorOrdem ?? throw new ArgumentNullException(nameof(valorOrdem));
            TipoOrdem = tipoOrdem;
        }

        public bool PertenceAcao(Acao acao) => Acao == acao;

        public bool CondicaoAtendida() => Acao.ValorAtual.MesmoValor(ValorGatilho);

        public bool DeveDisparar(Acao acao) => PertenceAcao(acao) && CondicaoAtendida();
    }
}
