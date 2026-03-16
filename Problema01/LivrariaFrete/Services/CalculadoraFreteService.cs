using Problema01.LivrariaFrete.Models;
using Problema01.LivrariaFrete.TiposDeEntrega;

namespace Problema01.LivrariaFrete.Services
{
    public class CalculadoraFreteService
    {
        private readonly ITipoDeEntrega _tipoDeEntrega;

        public CalculadoraFreteService(ITipoDeEntrega tipoDeEntrega)
        {
            _tipoDeEntrega = tipoDeEntrega;
        }

        public decimal Calcular(Pedido pedido)
        {
            return _tipoDeEntrega.CalcularValorEntrega(pedido.PesoTotal());
        }
    }
}