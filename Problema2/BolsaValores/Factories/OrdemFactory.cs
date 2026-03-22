using BolsaValores.Enums;
using BolsaValores.Models;

namespace BolsaValores.Factories
{

    public static class OrdemFactory
    {
        public static Ordem CriarOrdem(Investidor investidor, TipoOrdem tipo, Dinheiro valor)
        {
            return new Ordem(investidor, tipo, valor);
        }

        public static OrdemProgramada CriarOrdemProgramada(Acao acao, Dinheiro valorGatilho, TipoOrdem tipoOrdem, Dinheiro valorOrdem)
        {
            return new OrdemProgramada(acao, valorGatilho, tipoOrdem, valorOrdem);
        }
    }
}
