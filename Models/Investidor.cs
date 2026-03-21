using BolsaValores.Enums;
using BolsaValores.Interfaces;

namespace BolsaValores.Models
{
    public class Investidor : IInvestidorObserver
    {
        public string Nome { get; }
        private readonly List<OrdemProgramada> _ordensProgramadas = new();

        public Investidor(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do investidor é obrigatório.", nameof(nome));

            Nome = nome;
        }

        public void RegistrarOrdem(Acao acao, TipoOrdemEnum tipo, decimal valor)
        {
            var ordem = new Ordem(this, tipo, valor);
            acao.RegistrarOrdem(ordem);
        }

        public void AcompanharAcao(Acao acao)
        {
            acao.RegistrarObserver(this);
        }

        public void ProgramarOrdem(Acao acao, decimal valorGatilho, TipoOrdemEnum tipoOrdem, decimal valorOrdem)
        {
            var programacao = new OrdemProgramada(acao, valorGatilho, tipoOrdem, valorOrdem);
            _ordensProgramadas.Add(programacao);
            
            AcompanharAcao(acao);
        }

        public void Atualizar(Acao acao)
        {
            var ordensDisparadas = _ordensProgramadas
                .Where(op => op.Acao == acao && op.CondicaoAtendida())
                .ToList();

            foreach (var ordemProgramada in ordensDisparadas)
            {
        
                _ordensProgramadas.Remove(ordemProgramada); 
                        
                RegistrarOrdem(acao, ordemProgramada.TipoOrdem, ordemProgramada.ValorOrdem);
            }
        }
    }
}