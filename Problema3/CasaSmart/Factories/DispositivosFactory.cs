using AlgoritmosDotNet;
using CasaSmart.Adapters;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Factories
{
    public class DispositivosFactory
    {
        public static ILampada CriarLampada(TipoLampadaEnum tipo)
        {
            switch (tipo)
            {
                case TipoLampadaEnum.Phellipes:
                    return new LampadaPhelippesAdapter(new LampadaPhellipes());

                case TipoLampadaEnum.Shoyumi:
                    return new LampadaShoyuMiAdapter(new LampadaShoyuMi());

                default:
                    throw new ArgumentException("Tipo de lâmpada inválido");
            }
        }

        public static IArCondicionado CriarArCondicionado(TipoArCondicionadoEnum tipo)
        {
            switch (tipo)
            {
                case TipoArCondicionadoEnum.Ventobaumm:
                    return new ArCondicionadoVentoBaummAdapter(new ArCondicionadoVentoBaumn());

                case TipoArCondicionadoEnum.Gellakaza:
                    return new ArCondicionadoGellaKazaAdapter(new ArCondicionadoGellaKaza());

                default:
                    throw new ArgumentException("Tipo de ar-condicionado inválido");
            }
        }

        public static IPersiana CriarPersiana(TipoPersianaEnum tipo)
        {
            switch (tipo)
            {
                case TipoPersianaEnum.Solaris:
                    return new PersianaSolariusAdapter(new PersianaSolarius());

                case TipoPersianaEnum.Natlight:
                    return new PersianaNatLightAdapter(new PersianaNatLight());

                default:
                    throw new ArgumentException("Tipo de persiana inválido");
            }
        }
    }
}
