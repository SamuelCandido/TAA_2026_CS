using AlgoritmosDotNet;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using CasaSmart.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class ArCondicionadoGellaKazaAdapter: IArCondicionado, IDispositivoObserver
    {
        private ArCondicionadoGellaKaza _arCondicionado;

        public ArCondicionadoGellaKazaAdapter(ArCondicionadoGellaKaza arCondicionado)
        {
            _arCondicionado = arCondicionado;
        }
        
        public bool EstaLigado()
        {
            return _arCondicionado.EstaLigado();
        }        

        public void Ligar()
        {
            _arCondicionado.Ativar();
        }        

        public void Desligar()
        {
            _arCondicionado.Desativar();
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

        public void AumentarTemperatura()
        {
            _arCondicionado.AumentarTemperatura();
        }

        public void DiminuirTemperatura()
        {
            _arCondicionado.DiminuirTemperatura();
        }     

        public int GetTemperatura()
        {
            return _arCondicionado.GetTemperatura();
        }

        public void Atualizar(ModoCasaEnum modo)
        {
            if (modo == ModoCasaEnum.Sono)
                Desligar();
            else if (modo == ModoCasaEnum.Trabalho)
            {
                Ligar();
                DefinirTemperatura(ConstantesModos.TEMPERATURA_TRABALHO);
            }
        }
    }
}
