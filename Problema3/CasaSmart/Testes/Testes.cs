using CasaSmart.Enums;
using CasaSmart.Factories;
using CasaSmart.Interfaces;
using CasaSmart.Models;
using Xunit;

namespace CasaSmart.Testes
{
    public class DispositivoObserverDeTeste : IDispositivoObserver
    {
        public bool FoiAtualizado { get; private set; }
        public ModoCasaEnum? UltimoModo { get; private set; }

        public void Atualizar(ModoCasaEnum modo)
        {
            FoiAtualizado = true;
            UltimoModo = modo;
        }
    }

    public class CasaTestes
    {
        [Fact]
        public void AdicionarDispositivo_DeveAdicionarSemErro()
        {
            var casa = new Casa();
            var dispositivo = new DispositivoObserverDeTeste();

            casa.AdicionarDispositivo(dispositivo);

            casa.AtivarModoSono();
            Assert.True(dispositivo.FoiAtualizado);
        }

        [Fact]
        public void AtivarModoSono_DeveNotificarTodosDispositivos()
        {
            var casa = new Casa();
            var d1 = new DispositivoObserverDeTeste();
            var d2 = new DispositivoObserverDeTeste();
            casa.AdicionarDispositivo(d1);
            casa.AdicionarDispositivo(d2);

            casa.AtivarModoSono();

            Assert.True(d1.FoiAtualizado);
            Assert.Equal(ModoCasaEnum.Sono, d1.UltimoModo);
            Assert.True(d2.FoiAtualizado);
            Assert.Equal(ModoCasaEnum.Sono, d2.UltimoModo);
        }

        [Fact]
        public void AtivarModoTrabalho_DeveNotificarTodosDispositivos()
        {
            var casa = new Casa();
            var d1 = new DispositivoObserverDeTeste();
            var d2 = new DispositivoObserverDeTeste();
            casa.AdicionarDispositivo(d1);
            casa.AdicionarDispositivo(d2);

            casa.AtivarModoTrabalho();

            Assert.True(d1.FoiAtualizado);
            Assert.Equal(ModoCasaEnum.Trabalho, d1.UltimoModo);
            Assert.True(d2.FoiAtualizado);
            Assert.Equal(ModoCasaEnum.Trabalho, d2.UltimoModo);
        }

        [Fact]
        public void Notificar_SemDispositivos_NaoDeveLancarExcecao()
        {
            var casa = new Casa();
            var exception = Record.Exception(() => casa.Notificar(ModoCasaEnum.Sono));
            Assert.Null(exception);
        }

        [Fact]
        public void Notificar_ComModoSono_DeveEnviarModoCorreto()
        {
            var casa = new Casa();
            var dispositivo = new DispositivoObserverDeTeste();
            casa.AdicionarDispositivo(dispositivo);

            casa.Notificar(ModoCasaEnum.Sono);

            Assert.Equal(ModoCasaEnum.Sono, dispositivo.UltimoModo);
        }

        [Fact]
        public void Notificar_ComModoTrabalho_DeveEnviarModoCorreto()
        {
            var casa = new Casa();
            var dispositivo = new DispositivoObserverDeTeste();
            casa.AdicionarDispositivo(dispositivo);

            casa.Notificar(ModoCasaEnum.Trabalho);

            Assert.Equal(ModoCasaEnum.Trabalho, dispositivo.UltimoModo);
        }

        [Fact]
        public void AdicionarMultiplosDispositivos_TodosDevemSerNotificados()
        {
            var casa = new Casa();
            var dispositivos = new List<DispositivoObserverDeTeste>();
            for (int i = 0; i < 5; i++)
            {
                var d = new DispositivoObserverDeTeste();
                dispositivos.Add(d);
                casa.AdicionarDispositivo(d);
            }

            casa.AtivarModoSono();

            Assert.All(dispositivos, d =>
            {
                Assert.True(d.FoiAtualizado);
                Assert.Equal(ModoCasaEnum.Sono, d.UltimoModo);
            });
        }
    }

    public class DispositivosFactoryTestes
    {
        [Fact]
        public void CriarLampada_Phellipes_DeveRetornarILampada()
        {
            var lampada = LampadaFactory.CriarLampada(TipoLampadaEnum.Phellipes);
            Assert.NotNull(lampada);
            Assert.IsAssignableFrom<ILampada>(lampada);
        }

        [Fact]
        public void CriarLampada_Shoyumi_DeveRetornarILampada()
        {
            var lampada = LampadaFactory.CriarLampada(TipoLampadaEnum.Shoyumi);
            Assert.NotNull(lampada);
            Assert.IsAssignableFrom<ILampada>(lampada);
        }

        [Fact]
        public void CriarLampada_TipoInvalido_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() =>
                LampadaFactory.CriarLampada((TipoLampadaEnum)999));
        }

        [Fact]
        public void CriarArCondicionado_Ventobaumn_DeveRetornarIArCondicionado()
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(TipoArCondicionadoEnum.Ventobaumn);
            Assert.NotNull(ar);
            Assert.IsAssignableFrom<IArCondicionado>(ar);
        }

        [Fact]
        public void CriarArCondicionado_Gellakaza_DeveRetornarIArCondicionado()
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(TipoArCondicionadoEnum.Gellakaza);
            Assert.NotNull(ar);
            Assert.IsAssignableFrom<IArCondicionado>(ar);
        }

        [Fact]
        public void CriarArCondicionado_TipoInvalido_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() =>
                ArCondicionadoFactory.CriarArCondicionado((TipoArCondicionadoEnum)999));
        }

        [Fact]
        public void CriarPersiana_Solarius_DeveRetornarIPersiana()
        {
            var persiana = PersianaFactory.CriarPersiana(TipoPersianaEnum.Solarius);
            Assert.NotNull(persiana);
            Assert.IsAssignableFrom<IPersiana>(persiana);
        }

        [Fact]
        public void CriarPersiana_Natlight_DeveRetornarIPersiana()
        {
            var persiana = PersianaFactory.CriarPersiana(TipoPersianaEnum.Natlight);
            Assert.NotNull(persiana);
            Assert.IsAssignableFrom<IPersiana>(persiana);
        }

        [Fact]
        public void CriarPersiana_TipoInvalido_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() =>
                PersianaFactory.CriarPersiana((TipoPersianaEnum)999));
        }

        [Fact]
        public void CriarLampada_DeveRetornarTambemIDispositivoObserver()
        {
            var lampada = LampadaFactory.CriarLampada(TipoLampadaEnum.Phellipes);
            Assert.IsAssignableFrom<IDispositivoObserver>(lampada);
        }

        [Fact]
        public void CriarArCondicionado_DeveRetornarTambemIDispositivoObserver()
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(TipoArCondicionadoEnum.Ventobaumn);
            Assert.IsAssignableFrom<IDispositivoObserver>(ar);
        }

        [Fact]
        public void CriarPersiana_DeveRetornarTambemIDispositivoObserver()
        {
            var persiana = PersianaFactory.CriarPersiana(TipoPersianaEnum.Solarius);
            Assert.IsAssignableFrom<IDispositivoObserver>(persiana);
        }
    }

    public class LampadaAdapterTestes
    {
        [Theory]
        [InlineData(TipoLampadaEnum.Phellipes)]
        [InlineData(TipoLampadaEnum.Shoyumi)]
        public void Ligar_DeveEstarLigada(TipoLampadaEnum tipo)
        {
            var lampada = LampadaFactory.CriarLampada(tipo);
            lampada.Ligar();
            Assert.True(lampada.EstaLigada());
        }

        [Theory]
        [InlineData(TipoLampadaEnum.Phellipes)]
        [InlineData(TipoLampadaEnum.Shoyumi)]
        public void Desligar_DeveEstarDesligada(TipoLampadaEnum tipo)
        {
            var lampada = LampadaFactory.CriarLampada(tipo);
            lampada.Ligar();
            lampada.Desligar();
            Assert.False(lampada.EstaLigada());
        }

        [Theory]
        [InlineData(TipoLampadaEnum.Phellipes)]
        [InlineData(TipoLampadaEnum.Shoyumi)]
        public void Atualizar_ModoSono_DeveDesligar(TipoLampadaEnum tipo)
        {
            var lampada = LampadaFactory.CriarLampada(tipo);
            lampada.Ligar();
            ((IDispositivoObserver)lampada).Atualizar(ModoCasaEnum.Sono);
            Assert.False(lampada.EstaLigada());
        }

        [Theory]
        [InlineData(TipoLampadaEnum.Phellipes)]
        [InlineData(TipoLampadaEnum.Shoyumi)]
        public void Atualizar_ModoTrabalho_DeveLigar(TipoLampadaEnum tipo)
        {
            var lampada = LampadaFactory.CriarLampada(tipo);
            ((IDispositivoObserver)lampada).Atualizar(ModoCasaEnum.Trabalho);
            Assert.True(lampada.EstaLigada());
        }
    }

    public class ArCondicionadoAdapterTestes
    {
        [Theory]
        [InlineData(TipoArCondicionadoEnum.Ventobaumn)]
        [InlineData(TipoArCondicionadoEnum.Gellakaza)]
        public void Ligar_DeveEstarLigado(TipoArCondicionadoEnum tipo)
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(tipo);
            ar.Ligar();
            Assert.True(ar.EstaLigado());
        }

        [Theory]
        [InlineData(TipoArCondicionadoEnum.Ventobaumn)]
        [InlineData(TipoArCondicionadoEnum.Gellakaza)]
        public void Desligar_DeveEstarDesligado(TipoArCondicionadoEnum tipo)
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(tipo);
            ar.Ligar();
            ar.Desligar();
            Assert.False(ar.EstaLigado());
        }

        [Theory]
        [InlineData(TipoArCondicionadoEnum.Ventobaumn)]
        [InlineData(TipoArCondicionadoEnum.Gellakaza)]
        public void DefinirTemperatura_DeveAlterarTemperatura(TipoArCondicionadoEnum tipo)
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(tipo);
            ar.Ligar();
            ar.DefinirTemperatura(22);
            Assert.Equal(22, ar.GetTemperatura());
        }

        [Theory]
        [InlineData(TipoArCondicionadoEnum.Ventobaumn)]
        [InlineData(TipoArCondicionadoEnum.Gellakaza)]
        public void Atualizar_ModoSono_DeveDesligar(TipoArCondicionadoEnum tipo)
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(tipo);
            ar.Ligar();
            ((IDispositivoObserver)ar).Atualizar(ModoCasaEnum.Sono);
            Assert.False(ar.EstaLigado());
        }

        [Theory]
        [InlineData(TipoArCondicionadoEnum.Ventobaumn)]
        [InlineData(TipoArCondicionadoEnum.Gellakaza)]
        public void Atualizar_ModoTrabalho_DeveLigarEDefinirTemperatura25(TipoArCondicionadoEnum tipo)
        {
            var ar = ArCondicionadoFactory.CriarArCondicionado(tipo);
            ((IDispositivoObserver)ar).Atualizar(ModoCasaEnum.Trabalho);
            Assert.True(ar.EstaLigado());
            Assert.Equal(25, ar.GetTemperatura());
        }
    }

    public class PersianaAdapterTestes
    {
        [Theory]
        [InlineData(TipoPersianaEnum.Solarius)]
        [InlineData(TipoPersianaEnum.Natlight)]
        public void SubirPersiana_DeveEstarAberta(TipoPersianaEnum tipo)
        {
            var persiana = PersianaFactory.CriarPersiana(tipo);
            persiana.SubirPersiana();
            Assert.True(persiana.EstaAberta());
        }

        [Theory]
        [InlineData(TipoPersianaEnum.Solarius)]
        [InlineData(TipoPersianaEnum.Natlight)]
        public void DescerPersiana_DeveEstarFechada(TipoPersianaEnum tipo)
        {
            var persiana = PersianaFactory.CriarPersiana(tipo);
            persiana.SubirPersiana();
            persiana.DescerPersiana();
            Assert.False(persiana.EstaAberta());
        }

        [Theory]
        [InlineData(TipoPersianaEnum.Solarius)]
        [InlineData(TipoPersianaEnum.Natlight)]
        public void Atualizar_ModoSono_DeveDescer(TipoPersianaEnum tipo)
        {
            var persiana = PersianaFactory.CriarPersiana(tipo);
            persiana.SubirPersiana();
            ((IDispositivoObserver)persiana).Atualizar(ModoCasaEnum.Sono);
            Assert.False(persiana.EstaAberta());
        }

        [Theory]
        [InlineData(TipoPersianaEnum.Solarius)]
        [InlineData(TipoPersianaEnum.Natlight)]
        public void Atualizar_ModoTrabalho_DeveSubir(TipoPersianaEnum tipo)
        {
            var persiana = PersianaFactory.CriarPersiana(tipo);
            ((IDispositivoObserver)persiana).Atualizar(ModoCasaEnum.Trabalho);
            Assert.True(persiana.EstaAberta());
        }
    }

    public class IntegracaoTestes
    {
        [Fact]
        public void Casa_ModoSono_DeveDesligarTodosDispositivos()
        {
            var casa = new Casa();

            var lampada = LampadaFactory.CriarLampada(TipoLampadaEnum.Phellipes);
            var ar = ArCondicionadoFactory.CriarArCondicionado(TipoArCondicionadoEnum.Ventobaumn);
            var persiana = PersianaFactory.CriarPersiana(TipoPersianaEnum.Solarius);

            lampada.Ligar();
            ar.Ligar();
            persiana.SubirPersiana();

            casa.AdicionarDispositivo((IDispositivoObserver)lampada);
            casa.AdicionarDispositivo((IDispositivoObserver)ar);
            casa.AdicionarDispositivo((IDispositivoObserver)persiana);

            casa.AtivarModoSono();

            Assert.False(lampada.EstaLigada());
            Assert.False(ar.EstaLigado());
            Assert.False(persiana.EstaAberta());
        }

        [Fact]
        public void Casa_ModoTrabalho_DeveLigarTodosDispositivos()
        {
            var casa = new Casa();

            var lampada = LampadaFactory.CriarLampada(TipoLampadaEnum.Shoyumi);
            var ar = ArCondicionadoFactory.CriarArCondicionado(TipoArCondicionadoEnum.Gellakaza);
            var persiana = PersianaFactory.CriarPersiana(TipoPersianaEnum.Natlight);

            casa.AdicionarDispositivo((IDispositivoObserver)lampada);
            casa.AdicionarDispositivo((IDispositivoObserver)ar);
            casa.AdicionarDispositivo((IDispositivoObserver)persiana);

            casa.AtivarModoTrabalho();

            Assert.True(lampada.EstaLigada());
            Assert.True(ar.EstaLigado());
            Assert.Equal(25, ar.GetTemperatura());
            Assert.True(persiana.EstaAberta());
        }
    }
}
