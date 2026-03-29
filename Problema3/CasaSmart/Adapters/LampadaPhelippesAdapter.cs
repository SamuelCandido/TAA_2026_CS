using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AlgoritmosDotNet;
using CasaSmart.Enums;

namespace CasaSmart.Adapters
{
    public class LampadaPhelippesAdapter : ILampada, IDispositivoObserver
    {
        private LampadaPhellipes _lampada;

        public LampadaPhelippesAdapter(LampadaPhellipes lampada)
        {
            _lampada = lampada;
        }
        public void Ligar()
        {
            _lampada.SetIntensidade(100);
        }

        public void Desligar()
        {
            _lampada.SetIntensidade(0);
        }

        public bool EstaLigada()
        {
            return _lampada.GetIntensidade() > 0;
        }

        public void Atualizar(ModoCasaEnum modo)
        {
            if (modo == ModoCasaEnum.Sono)
                Desligar();

            if (modo == ModoCasaEnum.Trabalho)
                Ligar();
        }
    }
}
