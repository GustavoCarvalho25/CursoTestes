using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        [Fact(DisplayName = "Teste 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            ///Arrange
            var veiculo = new Veiculo();

            ///Act
            veiculo.Acelerar(10);

            ///Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            ///Arrange
            var veiculo = new Veiculo();

            ///Act
            veiculo.Frear(10);

            ///Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {
        
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Carlos Silva";
            carro.Placa = "ZAP-7419";
            carro.Cor = "Verde";
            carro.Modelo = "Variante";

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Tipo do Veiculo: Automovel", dados);
        }
    }
}
