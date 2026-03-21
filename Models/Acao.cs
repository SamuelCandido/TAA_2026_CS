using BolsaValores.Interfaces;

namespace BolsaValores.Models
{
    public class Acao
    {
        public string Nome { get; }
        public decimal ValorAtual { get; private set; }
        private readonly List<Ordem> _ordens = new();
        public IReadOnlyCollection<Ordem> Ordens => _ordens.AsReadOnly(); 
        
        private readonly List<IInvestidorObserver> _observadores = new();

        public Acao(string nome, decimal valorInicial)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da ação é obrigatório.", nameof(nome));

            Nome = nome;
            ValorAtual = valorInicial;
        }

        public void RegistrarObserver(IInvestidorObserver observador)
        {
            if (!_observadores.Contains(observador))
                _observadores.Add(observador);
        }

        public void RegistrarOrdem(Ordem novaOrdem)
        {
            var ordemMatch = BuscarOrdemCompativel(novaOrdem);

            if (ordemMatch != null)
                {ExecutarTransacao(ordemMatch, novaOrdem);}
            else
                { _ordens.Add(novaOrdem); }
        }

        private Ordem? BuscarOrdemCompativel(Ordem novaOrdem)
        {
            return _ordens.FirstOrDefault(o => o.Tipo != novaOrdem.Tipo && o.Valor == novaOrdem.Valor);
        }

        private void ExecutarTransacao(Ordem ordemExistente, Ordem novaOrdem)
        {
            _ordens.Remove(ordemExistente);
            AtualizarValor(novaOrdem.Valor);
        }

        private void AtualizarValor(decimal novoValor)
        {
            if (ValorAtual == novoValor) 
                return;

            ValorAtual = novoValor;
            NotificarObservadores();
        }

        private void NotificarObservadores()
        {
            var observadoresAtuais = _observadores.ToList();
            foreach (var observador in observadoresAtuais)
                { observador.Atualizar(this);}
        }
    }
}