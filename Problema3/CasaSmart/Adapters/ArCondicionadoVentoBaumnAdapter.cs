using AlgoritmosDotNet;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using CasaSmart.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class ArCondicionadoVentoBaumnAdapter : IArCondicionado, IDispositivoObserver
    {        
        private ArCondicionadoVentoBaumn _arCondicionado;

        public ArCondicionadoVentoBaumnAdapter(ArCondicionadoVentoBaumn arCondicionado)
        {
            _arCondicionado = arCondicionado;
        }

        public bool EstaLigado()
        {
            return _arCondicionado.EstaLigado();
        }

        public void Ligar()
        {
            _arCondicionado.Ligar();
        }        

        public void Desligar()
        {
            _arCondicionado.Desligar();
        }        

        public void DefinirTemperatura(int temperatura)
        {
            _arCondicionado.DefinirTemperatura(temperatura);
        }        

        public void AumentarTemperatura()
        {
            int temperatura = GetTemperatura();
            _arCondicionado.DefinirTemperatura(temperatura + 1);
        }

        public void DiminuirTemperatura()
        {
            int temperatura = GetTemperatura();
            _arCondicionado.DefinirTemperatura(temperatura - 1);
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
