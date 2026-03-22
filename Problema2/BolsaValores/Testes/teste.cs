using BolsaValores.Enums;
using BolsaValores.Factories;
using BolsaValores.Interfaces;
using BolsaValores.Models;
using Xunit;

namespace BolsaValores.Testes
{
    public class DinheiroTestes
    {
        [Fact]
        public void Criar_ComValorPositivo_DeveFuncionar()
        {
            var dinheiro = new Dinheiro(10.00m);
            Assert.Equal(10.00m, dinheiro.Quantia);
        }

        [Fact]
        public void Criar_ComValorInvalido_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Dinheiro(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Dinheiro(-5.00m));
        }

        [Fact]
        public void MesmoValor_DeveCompararCorretamente()
        {
            Assert.True(new Dinheiro(25.00m).MesmoValor(new Dinheiro(25.00m)));
            Assert.False(new Dinheiro(25.00m).MesmoValor(new Dinheiro(30.00m)));
        }

        [Fact]
        public void Equals_DeveCompararPorValor()
        {
            Assert.Equal(new Dinheiro(50.00m), new Dinheiro(50.00m));
        }
    }

    public class OrdemFactoryTestes
    {
        [Fact]
        public void CriarOrdem_DeveRetornarOrdemCorreta()
        {
            var investidor = new Investidor("Ana");
            var valor = new Dinheiro(30.00m);

            var ordem = OrdemFactory.CriarOrdem(investidor, TipoOrdem.Compra, valor);

            Assert.Equal(investidor, ordem.Investidor);
            Assert.Equal(TipoOrdem.Compra, ordem.Tipo);
            Assert.Equal(valor, ordem.Valor);
        }

        [Fact]
        public void CriarOrdemProgramada_DeveRetornarOrdemProgramadaCorreta()
        {
            var acao = new Acao("TEST", new Dinheiro(50.00m));
            var programada = OrdemFactory.CriarOrdemProgramada(acao, new Dinheiro(60.00m), TipoOrdem.Venda, new Dinheiro(60.00m));

            Assert.Equal(acao, programada.Acao);
            Assert.Equal(TipoOrdem.Venda, programada.TipoOrdem);
        }
    }

    public class AcaoTestes
    {
        [Fact]
        public void Criar_DeveDefinirNomeEValorInicial()
        {
            var acao = new Acao("BBAS3", new Dinheiro(25.00m));
            Assert.Equal("BBAS3", acao.Nome);
            Assert.Equal(25.00m, acao.ValorAtual.Quantia);
        }

        [Fact]
        public void Criar_NomeVazio_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new Acao("", new Dinheiro(10.00m)));
        }

        [Fact]
        public void RegistrarOrdem_SemMatch_DeveAdicionarNaLista()
        {
            var acao = new Acao("PETR4", new Dinheiro(30.00m));
            new Investidor("Ana").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(28.00m));
            Assert.Single(acao.Ordens);
        }

        [Fact]
        public void RegistrarOrdem_ComMatch_DeveRemoverOrdensEAtualizarValor()
        {
            var acao = new Acao("BBAS3", new Dinheiro(25.00m));
            new Investidor("Mariana").RegistrarOrdem(acao, TipoOrdem.Venda, new Dinheiro(24.00m));
            new Investidor("Joaquim").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(24.00m));

            Assert.Empty(acao.Ordens);
            Assert.Equal(24.00m, acao.ValorAtual.Quantia);
        }

        [Fact]
        public void RegistrarOrdem_MesmoTipo_NaoDeveFazerMatch()
        {
            var acao = new Acao("VALE3", new Dinheiro(50.00m));
            new Investidor("A").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(48.00m));
            new Investidor("B").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(48.00m));

            Assert.Equal(2, acao.Ordens.Count);
            Assert.Equal(50.00m, acao.ValorAtual.Quantia);
        }

        [Fact]
        public void RegistrarOrdem_ValoresDiferentes_NaoDeveFazerMatch()
        {
            var acao = new Acao("ITUB4", new Dinheiro(30.00m));
            new Investidor("A").RegistrarOrdem(acao, TipoOrdem.Venda, new Dinheiro(32.00m));
            new Investidor("B").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(31.00m));

            Assert.Equal(2, acao.Ordens.Count);
        }
    }

    public class OrdemTestes
    {
        [Fact]
        public void Criar_InvestidorNulo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentNullException>(() => OrdemFactory.CriarOrdem(null!, TipoOrdem.Compra, new Dinheiro(10.00m)));
        }

        [Fact]
        public void EhCompativelCom_TipoOpostoMesmoValor_DeveRetornarTrue()
        {
            var compra = OrdemFactory.CriarOrdem(new Investidor("A"), TipoOrdem.Compra, new Dinheiro(24.00m));
            var venda = OrdemFactory.CriarOrdem(new Investidor("B"), TipoOrdem.Venda, new Dinheiro(24.00m));
            Assert.True(compra.EhCompativelCom(venda));
        }

        [Fact]
        public void EhCompativelCom_MesmoTipo_DeveRetornarFalse()
        {
            var c1 = OrdemFactory.CriarOrdem(new Investidor("A"), TipoOrdem.Compra, new Dinheiro(24.00m));
            var c2 = OrdemFactory.CriarOrdem(new Investidor("B"), TipoOrdem.Compra, new Dinheiro(24.00m));
            Assert.False(c1.EhCompativelCom(c2));
        }

        [Fact]
        public void EhCompativelCom_ValoresDiferentes_DeveRetornarFalse()
        {
            var compra = OrdemFactory.CriarOrdem(new Investidor("A"), TipoOrdem.Compra, new Dinheiro(24.00m));
            var venda = OrdemFactory.CriarOrdem(new Investidor("B"), TipoOrdem.Venda, new Dinheiro(25.00m));
            Assert.False(compra.EhCompativelCom(venda));
        }
    }

    public class InvestidorTestes
    {
        [Fact]
        public void Criar_NomeVazio_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => new Investidor(""));
        }

        [Fact]
        public void AcompanharAcao_DeveReceberNotificacao()
        {
            var acao = new Acao("MGLU3", new Dinheiro(10.00m));
            var obs = new ObservadorDeTeste();
            acao.RegistrarObservador(obs);

            new Investidor("A").RegistrarOrdem(acao, TipoOrdem.Venda, new Dinheiro(12.00m));
            new Investidor("B").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(12.00m));

            Assert.True(obs.FoiNotificado);
            Assert.Equal(12.00m, obs.UltimoValor.Quantia);
        }

        [Fact]
        public void ProgramarOrdem_DeveDispararQuandoCondicaoAtendida()
        {
            var acao = new Acao("WEGE3", new Dinheiro(40.00m));
            var investidor = new Investidor("Clara");
            investidor.ProgramarOrdem(acao, new Dinheiro(45.00m), TipoOrdem.Venda, new Dinheiro(45.00m));

            new Investidor("X").RegistrarOrdem(acao, TipoOrdem.Venda, new Dinheiro(45.00m));
            new Investidor("Y").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(45.00m));

            Assert.Contains(acao.Ordens, o => o.Investidor == investidor && o.Tipo == TipoOrdem.Venda);
        }

        [Fact]
        public void ProgramarOrdem_NaoDeveDispararSeCondicaoNaoAtendida()
        {
            var acao = new Acao("ABEV3", new Dinheiro(15.00m));
            var investidor = new Investidor("Roberto");
            investidor.ProgramarOrdem(acao, new Dinheiro(20.00m), TipoOrdem.Compra, new Dinheiro(20.00m));

            new Investidor("V").RegistrarOrdem(acao, TipoOrdem.Venda, new Dinheiro(18.00m));
            new Investidor("C").RegistrarOrdem(acao, TipoOrdem.Compra, new Dinheiro(18.00m));

            Assert.DoesNotContain(acao.Ordens, o => o.Investidor == investidor);
        }
    }

    public class OrdemProgramadaTestes
    {
        [Fact]
        public void CondicaoAtendida_DeveRetornarCorretamente()
        {
            var acao = new Acao("TEST", new Dinheiro(100.00m));
            Assert.True(OrdemFactory.CriarOrdemProgramada(acao, new Dinheiro(100.00m), TipoOrdem.Venda, new Dinheiro(100.00m)).CondicaoAtendida());
            Assert.False(OrdemFactory.CriarOrdemProgramada(acao, new Dinheiro(110.00m), TipoOrdem.Compra, new Dinheiro(110.00m)).CondicaoAtendida());
        }

        [Fact]
        public void DeveDisparar_DeveRetornarFalse_QuandoAcaoDiferente()
        {
            var acao1 = new Acao("BBAS3", new Dinheiro(50.00m));
            var acao2 = new Acao("PETR4", new Dinheiro(50.00m));
            var programada = OrdemFactory.CriarOrdemProgramada(acao1, new Dinheiro(50.00m), TipoOrdem.Venda, new Dinheiro(50.00m));
            Assert.False(programada.DeveDisparar(acao2));
        }
    }

    public class ObservadorDeTeste : IObservadorDeAcao
    {
        public bool FoiNotificado { get; private set; }
        public Dinheiro UltimoValor { get; private set; } = null!;

        public void NotificarAlteracaoDeValor(Acao acao)
        {
            FoiNotificado = true;
            UltimoValor = acao.ValorAtual;
        }
    }
}
