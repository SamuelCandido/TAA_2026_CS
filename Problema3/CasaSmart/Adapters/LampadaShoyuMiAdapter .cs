using AlgoritmosDotNet;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class LampadaShoyuMiAdapter : ILampada, IDispositivoObserver
    {
        private LampadaShoyuMi _lampada;

        public LampadaShoyuMiAdapter(LampadaShoyuMi lampada)
        {
            _lampada = lampada;
        }

        public bool EstaLigada()
        {
            return _lampada.EstaLigada();
        }

        public void Ligar()
        {
            _lampada.Ligar();
        }

        public void Desligar()
        {
            _lampada.Desligar();
        }

        public void Atualizar(ModoCasaEnum modo)
        {
            if (modo == ModoCasaEnum.Sono)
                Desligar();
            else if (modo == ModoCasaEnum.Trabalho)
                Ligar();
        }
    }
}
