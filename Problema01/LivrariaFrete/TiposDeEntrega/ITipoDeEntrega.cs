using Problema01.LivrariaFrete.Models;

namespace Problema01.LivrariaFrete.TiposDeEntrega
{
    public interface ITipoDeEntrega
    {
        decimal CalcularValorEntrega(Peso peso);
    }
}