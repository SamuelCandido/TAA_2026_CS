using Problema01.LivrariaFrete.Enums;
using Problema01.LivrariaFrete.Factories;
using Problema01.LivrariaFrete.Models;
using Problema01.LivrariaFrete.Services;
using Problema01.LivrariaFrete.TiposDeEntrega;
using Xunit;

namespace Problema01.LivrariaFrete.Testes
{
    public class TesteTiposDeEntrega
    {
        [Fact]
        public void Peso_ZeroOuNegativo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Peso(0m, UnidadeDePesoEnum.QUILOGRAMA));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Peso(-1m, UnidadeDePesoEnum.QUILOGRAMA));
        }

        [Fact]
        public void Peso_ConversaoGramaParaQuilograma_DeveConverterCorretamente()
        {
            var peso = new Peso(1000m, UnidadeDePesoEnum.GRAMA);
            Assert.Equal(1000m, peso.EmGramas);
            Assert.Equal(1m, peso.EmQuilogramas);
        }

        [Fact]
        public void Peso_ConversaoQuilogramaParaGrama_DeveConverterCorretamente()
        {
            var peso = new Peso(2.5m, UnidadeDePesoEnum.QUILOGRAMA);
            Assert.Equal(2500m, peso.EmGramas);
            Assert.Equal(2.5m, peso.EmQuilogramas);
        }

        [Fact]
        public void Peso_ConversaoToneladaParaGrama_DeveConverterCorretamente()
        {
            var peso = new Peso(1m, UnidadeDePesoEnum.TONELADA);
            Assert.Equal(1000000m, peso.EmGramas);
            Assert.Equal(1000m, peso.EmQuilogramas);
            Assert.Equal(1m, peso.EmToneladas);
        }

        [Fact]
        public void Produto_DeveCriarComPropriedadesCorretas()
        {
            var peso = new Peso(500m, UnidadeDePesoEnum.GRAMA);
            var produto = new Produto("Livro", 29.90m, peso);

            Assert.Equal("Livro", produto.Nome);
            Assert.Equal(29.90m, produto.Valor);
            Assert.Equal(500m, produto.Peso.EmGramas);
        }

        [Fact]
        public void Produto_NomeVazio_DeveLancarExcecao()
        {
            var peso = new Peso(500m, UnidadeDePesoEnum.GRAMA);
            Assert.Throws<ArgumentException>(() => new Produto("", 29.90m, peso));
            Assert.Throws<ArgumentException>(() => new Produto("   ", 29.90m, peso));
        }

        [Fact]
        public void Produto_ValorNegativo_DeveLancarExcecao()
        {
            var peso = new Peso(500m, UnidadeDePesoEnum.GRAMA);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Produto("Livro", -1m, peso));
        }

        [Fact]
        public void Produto_PesoNulo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentNullException>(() => new Produto("Livro", 29.90m, null!));
        }

        [Fact]
        public void Pedido_AdicionarProduto_DeveAdicionarCorretamente()
        {
            var pedido = new Pedido();
            var produto = new Produto("Livro", 29.90m, new Peso(500m, UnidadeDePesoEnum.GRAMA));

            pedido.AdicionarProduto(produto);

            Assert.Equal(500m, pedido.PesoTotal().EmGramas);
        }

        [Fact]
        public void Pedido_PesoTotal_DeveSomarPesosDeTodosProdutos()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro 1", 20m, new Peso(300m, UnidadeDePesoEnum.GRAMA)));
            pedido.AdicionarProduto(new Produto("Livro 2", 30m, new Peso(700m, UnidadeDePesoEnum.GRAMA)));

            Assert.Equal(1000m, pedido.PesoTotal().EmGramas);
            Assert.Equal(1m, pedido.PesoTotal().EmQuilogramas);
        }

        [Fact]
        public void Pedido_PesoTotal_ComUnidadesDiferentes_DeveSomarCorretamente()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro", 20m, new Peso(500m, UnidadeDePesoEnum.GRAMA)));
            pedido.AdicionarProduto(new Produto("Enciclopédia", 100m, new Peso(1.5m, UnidadeDePesoEnum.QUILOGRAMA)));

            Assert.Equal(2000m, pedido.PesoTotal().EmGramas);
            Assert.Equal(2m, pedido.PesoTotal().EmQuilogramas);
        }

        [Fact]
        public void Pedido_PesoTotal_SemProdutos_DeveLancarExcecao()
        {
            var pedido = new Pedido();
            Assert.Throws<InvalidOperationException>(() => pedido.PesoTotal());
        }

        [Fact]
        public void Pedido_PossuiProdutos_DeveRetornarFalseQuandoVazio()
        {
            var pedido = new Pedido();
            Assert.False(pedido.PossuiProdutos());
        }

        [Fact]
        public void Pedido_PossuiProdutos_DeveRetornarTrueComProduto()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro", 20m, new Peso(500m, UnidadeDePesoEnum.GRAMA)));
            Assert.True(pedido.PossuiProdutos());
        }

        [Fact]
        public void EncomendaPAC_PesoAte1Kg_DeveRetornar10Reais()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(10.00m, pac.CalcularValorEntrega(new Peso(0.5m, UnidadeDePesoEnum.QUILOGRAMA)));
            Assert.Equal(10.00m, pac.CalcularValorEntrega(new Peso(1.0m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void EncomendaPAC_PesoEntre1e2Kg_DeveRetornar15Reais()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(15.00m, pac.CalcularValorEntrega(new Peso(1.5m, UnidadeDePesoEnum.QUILOGRAMA)));
            Assert.Equal(15.00m, pac.CalcularValorEntrega(new Peso(2.0m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void EncomendaPAC_PesoAcimaDe2Kg_DeveLancarExcecao()
        {
            var pac = new EncomendaPAC();
            Assert.Throws<ArgumentOutOfRangeException>(() => pac.CalcularValorEntrega(new Peso(2.1m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void EncomendaPAC_PesoEmGramas_DeveCalcularCorretamente()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(10.00m, pac.CalcularValorEntrega(new Peso(800m, UnidadeDePesoEnum.GRAMA)));
            Assert.Equal(15.00m, pac.CalcularValorEntrega(new Peso(1500m, UnidadeDePesoEnum.GRAMA)));
        }

        [Fact]
        public void Sedex_PesoAte500g_DeveRetornar12e50()
        {
            var sedex = new Sedex();
            Assert.Equal(12.50m, sedex.CalcularValorEntrega(new Peso(0.3m, UnidadeDePesoEnum.QUILOGRAMA)));
            Assert.Equal(12.50m, sedex.CalcularValorEntrega(new Peso(0.5m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void Sedex_PesoEntre500gE1Kg_DeveRetornar20Reais()
        {
            var sedex = new Sedex();
            Assert.Equal(20.00m, sedex.CalcularValorEntrega(new Peso(0.7m, UnidadeDePesoEnum.QUILOGRAMA)));
            Assert.Equal(20.00m, sedex.CalcularValorEntrega(new Peso(1.0m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void Sedex_PesoAcimaDe1Kg_DeveCalcularComBlocosAdicionais()
        {
            var sedex = new Sedex();
            Assert.Equal(48.00m, sedex.CalcularValorEntrega(new Peso(1.1m, UnidadeDePesoEnum.QUILOGRAMA)));            
            Assert.Equal(49.50m, sedex.CalcularValorEntrega(new Peso(1.2m, UnidadeDePesoEnum.QUILOGRAMA)));            
            Assert.Equal(51.00m, sedex.CalcularValorEntrega(new Peso(1.25m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void Sedex_PesoEmGramas_DeveCalcularCorretamente()
        {
            var sedex = new Sedex();
            Assert.Equal(12.50m, sedex.CalcularValorEntrega(new Peso(400m, UnidadeDePesoEnum.GRAMA)));
            Assert.Equal(20.00m, sedex.CalcularValorEntrega(new Peso(800m, UnidadeDePesoEnum.GRAMA)));
        }

        [Fact]
        public void RetiradaLocal_QualquerPesoValido_DeveRetornarZero()
        {
            var retirada = new RetiradaLocal();
            Assert.Equal(0.00m, retirada.CalcularValorEntrega(new Peso(0.5m, UnidadeDePesoEnum.QUILOGRAMA)));
            Assert.Equal(0.00m, retirada.CalcularValorEntrega(new Peso(5.0m, UnidadeDePesoEnum.QUILOGRAMA)));
            Assert.Equal(0.00m, retirada.CalcularValorEntrega(new Peso(100.0m, UnidadeDePesoEnum.QUILOGRAMA)));
        }

        [Fact]
        public void Factory_DeveRetornarEncomendaPAC()
        {
            var tipo = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.ENCOMENDA_PAC);
            Assert.IsType<EncomendaPAC>(tipo);
        }

        [Fact]
        public void Factory_DeveRetornarSedex()
        {
            var tipo = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.SEDEX);
            Assert.IsType<Sedex>(tipo);
        }

        [Fact]
        public void Factory_DeveRetornarRetiradaLocal()
        {
            var tipo = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.RETIRADA_LOCAL);
            Assert.IsType<RetiradaLocal>(tipo);
        }

        [Fact]
        public void CalculadoraFrete_ComPAC_DeveCalcularCorretamente()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro", 50m, new Peso(800m, UnidadeDePesoEnum.GRAMA)));

            var tipoEntrega = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.ENCOMENDA_PAC);
            var calculadora = new CalculadoraFreteService(tipoEntrega);

            Assert.Equal(10.00m, calculadora.Calcular(pedido));
        }

        [Fact]
        public void CalculadoraFrete_ComSedex_DeveCalcularCorretamente()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro", 50m, new Peso(600m, UnidadeDePesoEnum.GRAMA)));

            var tipoEntrega = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.SEDEX);
            var calculadora = new CalculadoraFreteService(tipoEntrega);

            Assert.Equal(20.00m, calculadora.Calcular(pedido));
        }

        [Fact]
        public void CalculadoraFrete_ComRetiradaLocal_DeveRetornarZero()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro", 50m, new Peso(5m, UnidadeDePesoEnum.QUILOGRAMA)));

            var tipoEntrega = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.RETIRADA_LOCAL);
            var calculadora = new CalculadoraFreteService(tipoEntrega);

            Assert.Equal(0.00m, calculadora.Calcular(pedido));
        }

        [Fact]
        public void CalculadoraFrete_ComMultiplosProdutos_DeveCalcularPesoTotal()
        {
            var pedido = new Pedido();
            pedido.AdicionarProduto(new Produto("Livro 1", 30m, new Peso(400m, UnidadeDePesoEnum.GRAMA)));
            pedido.AdicionarProduto(new Produto("Livro 2", 40m, new Peso(400m, UnidadeDePesoEnum.GRAMA)));

            var tipoEntrega = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntregaEnum.SEDEX);
            var calculadora = new CalculadoraFreteService(tipoEntrega);

            Assert.Equal(20.00m, calculadora.Calcular(pedido));
        }
    }
}