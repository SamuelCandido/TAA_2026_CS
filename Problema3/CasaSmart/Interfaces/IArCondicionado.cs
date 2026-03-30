using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Interfaces
{
    public interface IArCondicionado
    {
        const int TEMPERATURA_TRABALHO = 25;

        void Ligar();
        void Desligar();
        void AumentarTemperatura();
        void DiminuirTemperatura();
        void DefinirTemperatura(int temperatura);
        bool EstaLigado();
        int GetTemperatura();
    }
}
