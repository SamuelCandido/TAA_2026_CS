using System;
using Xunit;
using Problema01.TiposDeEntrega;

namespace Problema01.Teste
{
    public class TesteTiposDeEntrega
    {
        // Testes Peso
        [Fact]
        public void Peso_ZeroOuNegativo_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Peso(0m, UnidadeDePeso.QUILOGRAMA));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Peso(-1m, UnidadeDePeso.QUILOGRAMA));
        }

        // Testes EncomendaPAC
        [Fact]
        public void EncomendaPAC_PesoAte1Kg_DeveRetornar10Reais()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(10.00m, pac.CalcularValorEntrega(new Peso(0.5m, UnidadeDePeso.QUILOGRAMA)));
            Assert.Equal(10.00m, pac.CalcularValorEntrega(new Peso(1.0m, UnidadeDePeso.QUILOGRAMA)));
        }

        [Fact]
        public void EncomendaPAC_PesoEntre1e2Kg_DeveRetornar15Reais()
        {
            var pac = new EncomendaPAC();
            Assert.Equal(15.00m, pac.CalcularValorEntrega(new Peso(1.5m, UnidadeDePeso.QUILOGRAMA)));
            Assert.Equal(15.00m, pac.CalcularValorEntrega(new Peso(2.0m, UnidadeDePeso.QUILOGRAMA)));
        }

        [Fact]
        public void EncomendaPAC_PesoAcimaDe2Kg_DeveLancarExcecao()
        {
            var pac = new EncomendaPAC();
            Assert.Throws<ArgumentOutOfRangeException>(() => pac.CalcularValorEntrega(new Peso(2.1m, UnidadeDePeso.QUILOGRAMA)));
        }

        // Testes Sedex
        [Fact]
        public void Sedex_PesoAte500g_DeveRetornar12e50()
        {
            var sedex = new Sedex();
            Assert.Equal(12.50m, sedex.CalcularValorEntrega(new Peso(0.3m, UnidadeDePeso.QUILOGRAMA)));
            Assert.Equal(12.50m, sedex.CalcularValorEntrega(new Peso(0.5m, UnidadeDePeso.QUILOGRAMA)));
        }

        [Fact]
        public void Sedex_PesoEntre500gE1Kg_DeveRetornar20Reais()
        {
            var sedex = new Sedex();
            Assert.Equal(20.00m, sedex.CalcularValorEntrega(new Peso(0.7m, UnidadeDePeso.QUILOGRAMA)));
            Assert.Equal(20.00m, sedex.CalcularValorEntrega(new Peso(1.0m, UnidadeDePeso.QUILOGRAMA)));
        }

        [Fact]
        public void Sedex_PesoAcimaDe1Kg_DeveCalcularComBlocosAdicionais()
        {
            var sedex = new Sedex();
            Assert.Equal(48.00m, sedex.CalcularValorEntrega(new Peso(1.1m, UnidadeDePeso.QUILOGRAMA)));            
            Assert.Equal(49.50m, sedex.CalcularValorEntrega(new Peso(1.2m, UnidadeDePeso.QUILOGRAMA)));            
            Assert.Equal(51.00m, sedex.CalcularValorEntrega(new Peso(1.25m, UnidadeDePeso.QUILOGRAMA)));
        }

        // Testes RetiradaLocal
        [Fact]
        public void RetiradaLocal_QualquerPesoValido_DeveRetornarZero()
        {
            var retirada = new RetiradaLocal();
            Assert.Equal(0.00m, retirada.CalcularValorEntrega(new Peso(0.5m, UnidadeDePeso.QUILOGRAMA)));
            Assert.Equal(0.00m, retirada.CalcularValorEntrega(new Peso(5.0m, UnidadeDePeso.QUILOGRAMA)));
            Assert.Equal(0.00m, retirada.CalcularValorEntrega(new Peso(100.0m, UnidadeDePeso.QUILOGRAMA)));
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