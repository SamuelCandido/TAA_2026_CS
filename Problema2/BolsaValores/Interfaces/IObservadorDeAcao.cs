using BolsaValores.Models;

namespace BolsaValores.Interfaces
{

    public interface IObservadorDeAcao
    {
        void NotificarAlteracaoDeValor(Acao acao);
    }
}
