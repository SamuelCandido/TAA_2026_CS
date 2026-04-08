using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AlgoritmosDotNet;
using CasaSmart.Enums;

namespace CasaSmart.Adapters
{
    public class LampadaPhellipesAdapter : ILampada, IDispositivoObserver
    {
        private LampadaPhellipes _lampada;
        private const int INTENSIDADE_MINIMA = 0;
        private const int INTENSIDADE_MAXIMA = 100;

        public LampadaPhellipesAdapter(LampadaPhellipes lampada)
        {
            _lampada = lampada;
        }
        
        public bool EstaLigada()
        {
            return _lampada.GetIntensidade() > INTENSIDADE_MINIMA;
        }

        public void Ligar()
        {
            _lampada.SetIntensidade(INTENSIDADE_MAXIMA);
        }

        public void Desligar()
        {
            _lampada.SetIntensidade(INTENSIDADE_MINIMA);
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
