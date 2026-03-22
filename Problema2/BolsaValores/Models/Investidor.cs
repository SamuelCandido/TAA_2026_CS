using BolsaValores.Enums;
using BolsaValores.Factories;
using BolsaValores.Interfaces;

namespace BolsaValores.Models
{

    public class Investidor : IObservadorDeAcao
    {
        public string Nome { get; }
        private readonly List<OrdemProgramada> _ordensProgramadas = new();

        public Investidor(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do investidor é obrigatório.", nameof(nome));

            Nome = nome;
        }

        public void RegistrarOrdem(Acao acao, TipoOrdem tipo, Dinheiro valor)
        {
            var ordem = OrdemFactory.CriarOrdem(this, tipo, valor);
            acao.RegistrarOrdem(ordem);
        }

        public void AcompanharAcao(Acao acao)
        {
            acao.RegistrarObservador(this);
        }

        public void ProgramarOrdem(Acao acao, Dinheiro valorGatilho, TipoOrdem tipoOrdem, Dinheiro valorOrdem)
        {
            var programacao = OrdemFactory.CriarOrdemProgramada(acao, valorGatilho, tipoOrdem, valorOrdem);
            _ordensProgramadas.Add(programacao);
            AcompanharAcao(acao);
        }

        public void NotificarAlteracaoDeValor(Acao acao)
        {
            var ordensParaDisparar = _ordensProgramadas
                .Where(ordem => ordem.DeveDisparar(acao))
                .ToList();

            foreach (var ordemProgramada in ordensParaDisparar)
            {
                _ordensProgramadas.Remove(ordemProgramada);
                RegistrarOrdem(acao, ordemProgramada.TipoOrdem, ordemProgramada.ValorOrdem);
            }
        }
    }
}
