using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado.");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Gustavo Carvalho";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "abc-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Gustavo C", "AWS-1234", "Cinza", "Golbola")]
        [InlineData("Joao A", "ABC-1234", "Verde", "Fusca")]
        [InlineData("Gabriel S", "AAA-5678", "Roxo", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(
            string proprietario,
            string placa,
            string cor,
            string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Gustavo C", "AWS-1234", "Cinza", "Golbola")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(
            string proprietario,
            string placa,
            string cor,
            string modelo)
        {
            //Arrange
            Patio estacionamento = new Patio();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            veiculo.Proprietario = "Gustavo Carvalho";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "abc-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Gustavo Carvalho";
            veiculoAlterado.Cor = "Preto";//Alterado
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "abc-9999";

            //Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
