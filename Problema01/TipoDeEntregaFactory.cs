using Problema01.TiposDeEntrega;
using System;

namespace Problema01
{
    public class TipoDeEntregaFactory
    {
        public static ITipoDeEntrega CriarTipoDeEntrega(TipoDeEntrega tipoEntidade)
        {
            switch (tipoEntidade)
            {
                case TipoDeEntrega.ENCOMENDA_PAC:
                    return new EncomendaPAC();
                case TipoDeEntrega.RETIRADA_LOCAL:
                    return new RetiradaLocal();
                case TipoDeEntrega.SEDEX:
                    return new Sedex();
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoEntidade), "Tipo de entrega não suportado.");
            }
        }
    }
}