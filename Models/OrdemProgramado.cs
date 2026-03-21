using BolsaValores.Enums;

namespace BolsaValores.Models
{
    public class OrdemProgramada
    {
        public Acao Acao { get; }
        public decimal ValorGatilho { get; }
        public TipoOrdemEnum TipoOrdem { get; }
        public decimal ValorOrdem { get; }

        public OrdemProgramada(Acao acao, decimal valorGatilho, TipoOrdemEnum tipoOrdem, decimal valorOrdem)
        {
            if (valorGatilho <= 0 || valorOrdem <= 0)
                throw new ArgumentOutOfRangeException("Valores de gatilho e de ordem devem ser maiores que zero.");

            Acao = acao ?? throw new ArgumentNullException(nameof(acao));
            ValorGatilho = valorGatilho;
            TipoOrdem = tipoOrdem;
            ValorOrdem = valorOrdem;
        }
        
        public bool CondicaoAtendida() => Acao.ValorAtual == ValorGatilho;
    }
}