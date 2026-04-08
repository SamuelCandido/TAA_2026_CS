using AlgoritmosDotNet;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class PersianaSolariusAdapter : IPersiana, IDispositivoObserver
    {
        private PersianaSolarius _persiana;

        public PersianaSolariusAdapter(PersianaSolarius persiana)
        {
            _persiana = persiana;
        }

        public bool EstaAberta()
        {
            return _persiana.EstaAberta();
        }    

        public void SubirPersiana()
        {
            _persiana.SubirPersiana();
        }

        public void DescerPersiana()
        {
            _persiana.DescerPersiana();
        }

        public void Atualizar(ModoCasaEnum modo)
        {
            if (modo == ModoCasaEnum.Sono)
                DescerPersiana();
            else if (modo == ModoCasaEnum.Trabalho)
                SubirPersiana();
        }


    }
}
