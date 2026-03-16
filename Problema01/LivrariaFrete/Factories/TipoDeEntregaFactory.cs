using Problema01.LivrariaFrete.Enums;
using Problema01.LivrariaFrete.TiposDeEntrega;

namespace Problema01.LivrariaFrete.Factories
{
    public class TipoDeEntregaFactory
    {
        public static ITipoDeEntrega CriarTipoDeEntrega(TipoDeEntregaEnum tipo)
        {
            switch (tipo)
            {
                case TipoDeEntregaEnum.ENCOMENDA_PAC:
                    return new EncomendaPAC();
                case TipoDeEntregaEnum.RETIRADA_LOCAL:
                    return new RetiradaLocal();
                case TipoDeEntregaEnum.SEDEX:
                    return new Sedex();
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de entrega não suportado.");
            }
        }
    }
}