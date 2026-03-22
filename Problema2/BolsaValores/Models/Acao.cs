using BolsaValores.Interfaces;

namespace BolsaValores.Models
{

    public class Acao
    {
        public string Nome { get; }
        public Dinheiro ValorAtual { get; private set; }

        private readonly List<Ordem> _ordens = new();
        private readonly List<IObservadorDeAcao> _observadores = new();

        public IReadOnlyCollection<Ordem> Ordens => _ordens.AsReadOnly();

        public Acao(string nome, Dinheiro valorInicial)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da ação é obrigatório.", nameof(nome));

            Nome = nome;
            ValorAtual = valorInicial ?? throw new ArgumentNullException(nameof(valorInicial));
        }

        public void RegistrarObservador(IObservadorDeAcao observador)
        {
            if (_observadores.Contains(observador))
                return;

            _observadores.Add(observador);
        }

        public void RegistrarOrdem(Ordem novaOrdem)
        {
            var ordemCompativel = BuscarOrdemCompativel(novaOrdem);

            if (ordemCompativel is null)
            {
                _ordens.Add(novaOrdem);
                return;
            }

            ExecutarTransacao(ordemCompativel, novaOrdem);
        }

        private Ordem? BuscarOrdemCompativel(Ordem novaOrdem)
        {
            return _ordens.FirstOrDefault(existente => existente.EhCompativelCom(novaOrdem));
        }

        private void ExecutarTransacao(Ordem ordemExistente, Ordem novaOrdem)
        {
            _ordens.Remove(ordemExistente);
            AtualizarValor(novaOrdem.Valor);
        }

        private void AtualizarValor(Dinheiro novoValor)
        {
            if (ValorAtual.MesmoValor(novoValor))
                return;

            ValorAtual = novoValor;
            NotificarObservadores();
        }

        private void NotificarObservadores()
        {
            foreach (var observador in _observadores.ToList())
            {
                observador.NotificarAlteracaoDeValor(this);
            }
        }
    }
}
