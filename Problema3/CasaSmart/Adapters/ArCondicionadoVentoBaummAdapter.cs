using AlgoritmosDotNet;
using CasaSmart.Enums;
using CasaSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Adapters
{
    public class ArCondicionadoVentoBaummAdapter : IArCondicionado, IDispositivoObserver
    {
        private ArCondicionadoVentoBaumn _arCondicionado;

        public ArCondicionadoVentoBaummAdapter(ArCondicionadoVentoBaumn arCondicionado)
        {
            _arCondicionado = arCondicionado;
        }

        public void AumentarTemperatura()
        {
            int temperatura = GetTemperatura();
            _arCondicionado.DefinirTemperatura(temperatura + 1);
        }

        public void DefinirTemperatura(int temperatura)
        {
            _arCondicionado.DefinirTemperatura(temperatura);
        }

        public void Desligar()
        {
            _arCondicionado.Desligar();
        }

        public void DiminuirTemperatura()
        {
            int temperatura = GetTemperatura();
            _arCondicionado.DefinirTemperatura(temperatura - 1);
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
            _arCondicionado.Ligar();
        }

        public void Atualizar(ModoCasaEnum modo)
        {
            if (modo == ModoCasaEnum.Sono)
                Desligar();

            if (modo == ModoCasaEnum.Trabalho)
            {
                Ligar();
                DefinirTemperatura(25);
            }
                
        }
    }
}
