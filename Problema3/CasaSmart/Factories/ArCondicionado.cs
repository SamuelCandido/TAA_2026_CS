using AlgoritmosDotNet;
using CasaSmart.Adapters;
using CasaSmart.Enums;
using CasaSmart.Interfaces;

namespace CasaSmart.Factories
{
    public class ArCondicionadoFactory
    {
        public static IArCondicionado CriarArCondicionado(TipoArCondicionadoEnum tipo)
        {
            switch (tipo)
            {
                case TipoArCondicionadoEnum.Ventobaumn:
                    return new ArCondicionadoVentoBaumnAdapter(new ArCondicionadoVentoBaumn());

                case TipoArCondicionadoEnum.Gellakaza:
                    return new ArCondicionadoGellaKazaAdapter(new ArCondicionadoGellaKaza());

                default:
                    throw new ArgumentException("Tipo de ar-condicionado inválido");
            }
        }
    }
}