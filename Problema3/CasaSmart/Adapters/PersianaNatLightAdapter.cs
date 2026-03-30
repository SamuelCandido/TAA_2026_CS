using AlgoritmosDotNet;
using CasaSmart.Interfaces;
using CasaSmart.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class PersianaNatLightAdapter: IPersiana, IDispositivoObserver
    {
        private PersianaNatLight _persiana;

        public PersianaNatLightAdapter(PersianaNatLight persiana)
        {
            _persiana = persiana;
        }

        public bool EstaAberta()
        {
            return _persiana.EstaPalhetaAberta() && _persiana.EstaPalhetaErguida();
        }

        public void SubirPersiana()
        {
            AbrirPalheta();
            _persiana.SubirPalheta();
        }
       
        public void DescerPersiana()
        {
            _persiana.DescerPalheta();
            FecharPalheta();
        }

        public void FecharPalheta()
        {
            _persiana.FecharPalheta();
        }

        public void AbrirPalheta()
        {
            _persiana.AbrirPalheta();
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
