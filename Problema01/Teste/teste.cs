using System;
using Xunit;
using Problema01.TiposDeEntrega;

namespace Problema01.Teste
{
    public class TesteTiposDeEntrega
    {
        // Testes EncomendaPAC
        [Fact]
        public void EncomendaPAC_PesoAte1Kg_DeveRetornar10Reais()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(10.00, pac.CalcularValorEntrega(0.5));
            Assert.Equal(10.00, pac.CalcularValorEntrega(1.0));
        }

        [Fact]
        public void EncomendaPAC_PesoEntre1e2Kg_DeveRetornar15Reais()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(15.00, pac.CalcularValorEntrega(1.5));
            Assert.Equal(15.00, pac.CalcularValorEntrega(2.0));
        }

        [Fact]
        public void EncomendaPAC_PesoAcimaDe2Kg_DeveLancarExcecao()
        {
            var pac = new EncomendaPAC();
            Assert.Throws<ArgumentOutOfRangeException>(() => pac.CalcularValorEntrega(2.1));
        }

        [Fact]
        public void EncomendaPAC_PesoZeroOuNegativo_DeveLancarExcecao()
        {
            var pac = new EncomendaPAC();
            Assert.Throws<ArgumentOutOfRangeException>(() => pac.CalcularValorEntrega(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => pac.CalcularValorEntrega(-1));
        }

        // Testes Sedex
        [Fact]
        public void Sedex_PesoAte500g_DeveRetornar12e50()
        {
            var sedex = new Sedex();
            Assert.Equal(12.50, sedex.CalcularValorEntrega(0.3));
            Assert.Equal(12.50, sedex.CalcularValorEntrega(0.5));
        }

        [Fact]
        public void Sedex_PesoEntre500gE1Kg_DeveRetornar20Reais()
        {
            var sedex = new Sedex();
            Assert.Equal(20.00, sedex.CalcularValorEntrega(0.7));
            Assert.Equal(20.00, sedex.CalcularValorEntrega(1.0));
        }

        [Fact]
        public void Sedex_PesoAcimaDe1Kg_DeveCalcularComBlocosAdicionais()
        {
            var sedex = new Sedex();
            // 1.1kg = 100g adicional = 1 bloco = 46.50 + 1.50 = 48.00
            Assert.Equal(48.00, sedex.CalcularValorEntrega(1.1));
            // 1.2kg = 200g adicional = 2 blocos = 46.50 + 3.00 = 49.50
            Assert.Equal(49.50, sedex.CalcularValorEntrega(1.2));
            // 1.25kg = 250g adicional = 3 blocos = 46.50 + 4.50 = 51.00
            Assert.Equal(51.00, sedex.CalcularValorEntrega(1.25));
        }

        [Fact]
        public void Sedex_PesoZeroOuNegativo_DeveLancarExcecao()
        {
            var sedex = new Sedex();
            Assert.Throws<ArgumentOutOfRangeException>(() => sedex.CalcularValorEntrega(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => sedex.CalcularValorEntrega(-0.5));
        }

        // Testes RetiradaLocal
        [Fact]
        public void RetiradaLocal_QualquerPesoValido_DeveRetornarZero()
        {
            var retirada = new RetiradaLocal();
            Assert.Equal(0.00, retirada.CalcularValorEntrega(0.5));
            Assert.Equal(0.00, retirada.CalcularValorEntrega(5.0));
            Assert.Equal(0.00, retirada.CalcularValorEntrega(100.0));
        }

        [Fact]
        public void RetiradaLocal_PesoZeroOuNegativo_DeveLancarExcecao()
        {
            var retirada = new RetiradaLocal();
            Assert.Throws<ArgumentOutOfRangeException>(() => retirada.CalcularValorEntrega(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => retirada.CalcularValorEntrega(-1));
        }

        // Testes Factory
        [Fact]
        public void Factory_DeveRetornarEncomendaPAC()
        {
            var tipo = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntrega.ENCOMENDA_PAC);
            Assert.IsType<EncomendaPAC>(tipo);
        }

        [Fact]
        public void Factory_DeveRetornarSedex()
        {
            var tipo = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntrega.SEDEX);
            Assert.IsType<Sedex>(tipo);
        }

        [Fact]
        public void Factory_DeveRetornarRetiradaLocal()
        {
            var tipo = TipoDeEntregaFactory.CriarTipoDeEntrega(TipoDeEntrega.RETIRADA_LOCAL);
            Assert.IsType<RetiradaLocal>(tipo);
        }
    }
}
