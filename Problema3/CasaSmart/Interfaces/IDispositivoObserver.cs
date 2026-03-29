using System;
using System.Collections.Generic;
using System.Text;
using CasaSmart.Enums;

namespace CasaSmart.Interfaces
{
    public interface IDispositivoObserver
    {
        void Atualizar(ModoCasaEnum modo);
    }
}
