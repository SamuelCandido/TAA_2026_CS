using AlgoritmosDotNet;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class ArCondicionadoGellaKazaAdapter: IArCondicionado, IDispositivoObserver
    {
        private const int TemperaturaTrabalho = 25;
        private ArCondicionadoGellaKaza _arCondicionado;

        public ArCondicionadoGellaKazaAdapter(ArCondicionadoGellaKaza arCondicionado)
        {
            _arCondicionado = arCondicionado;
        }

        public void AumentarTemperatura()
        {
            _arCondicionado.AumentarTemperatura();
        }

        public void Desligar()
        {
            _arCondicionado.Desativar();
        }

        public void DiminuirTemperatura()
        {
            _arCondicionado.DiminuirTemperatura();
        }

        public bool EstaLigado()
        {
            return _arCondicionado.EstaLigado();
        }

        public int GetTemperatura()
        {
            return _arCondicionado.GetTemperatura();
        }

        public void Ligar()
        {
            _arCondicionado.Ativar();
        }

        public void Atualizar(ModoCasaEnum modo)
        {
            if (modo == ModoCasaEnum.Sono)
                Desligar();
            else if (modo == ModoCasaEnum.Trabalho)
            {
                Ligar();
                DefinirTemperatura(TemperaturaTrabalho);
            }
        }

        public void DefinirTemperatura(int temperatura)
        {
            int temperaturaAtual = GetTemperatura();
            while(temperaturaAtual != temperatura)
            {
                if(temperaturaAtual < temperatura)
                {
                    AumentarTemperatura();
                }
                else if(temperaturaAtual > temperatura)
                {
                    DiminuirTemperatura();
                }

                temperaturaAtual = GetTemperatura();
            }
        }
    }
}
