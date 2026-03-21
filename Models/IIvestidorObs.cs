using BolsaValores.Models;

namespace BolsaValores.Interfaces
{
    public interface IInvestidorObserver
    {
        void Atualizar(Acao acao);
    }
}