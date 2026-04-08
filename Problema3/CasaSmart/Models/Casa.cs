using System;
using System.Collections.Generic;
using System.Text;
using CasaSmart.Enums;
using CasaSmart.Interfaces;

namespace CasaSmart.Models
{
    public class Casa
    {
        private List<IDispositivoObserver> _dispositivos = new();

        public void AdicionarDispositivo(IDispositivoObserver dispositivo)
        {
            _dispositivos.Add(dispositivo);
        }

        public void Notificar(ModoCasaEnum modo)
        {
            foreach(IDispositivoObserver dispositivo in _dispositivos)
            {
                dispositivo.Atualizar(modo);
            }
        }

        public void AtivarModoSono()
        {
            Notificar(ModoCasaEnum.Sono);
        }

        public void AtivarModoTrabalho()
        {
            Notificar(ModoCasaEnum.Trabalho);
        }
    }
}
