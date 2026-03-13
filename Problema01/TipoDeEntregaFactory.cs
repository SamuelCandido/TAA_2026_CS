using Problema01.TiposDeEntrega;

namespace Problema01
{
    public class TipoDeEntregaFactory
    {
        public static ITipoDeEntrega CriarTipoDeEntrega(TipoDeEntrega tipoDeEntrega)
        {
            switch (tipoDeEntrega)
            {
                case TipoDeEntrega.ENCOMENDA_PAC:
                    return new EncomendaPAC();
                case TipoDeEntrega.RETIRADA_LOCAL:
                    return new RetiradaLocal();
                case TipoDeEntrega.SEDEX:
                    return new Sedex();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}