using System;
using System.Collections.Generic;
using System.Text;

namespace CasaSmart.Interfaces
{
    public interface ILampada
    {
        void Ligar();
        void Desligar();
        bool EstaLigada();

    }
}
