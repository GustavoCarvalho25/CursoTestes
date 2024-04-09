using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            veiculo = new Veiculo();
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado.");
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            ///Arrange

            ///Act
            veiculo.Acelerar(10);

            ///Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            ///Arrange

            ///Act
            veiculo.Frear(10);

            ///Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoDoVeiculo()
        {
            //Arrange

            //Act
            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
        
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veiculo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {

            //Arrange
            string nomeProprietario = "Bc";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
             );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDePlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placaFormatoErrado = "ASD-995U";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa = placaFormatoErrado
            );

        }

    }
}
