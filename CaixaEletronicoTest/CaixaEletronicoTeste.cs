using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CaixaEletronicoTest
{
    [TestClass]
    public class CaixaEletronicoTeste
    {

        [TestMethod]
        [ExpectedException(typeof(SaqueException))]
        public void DeveRetornarExceptionQuandoNaoHouverPossibilidadeDeSaque()
        {
            CaixaEletronico.EfetuarSaque(15);
        }

        [TestMethod]
        public void DeveRetornarFalseQuandoNaoHouverPossibilidadeDeSaque()
        {
            double valorSolicitado = 22;

            Assert.IsFalse(CaixaEletronico.VerificarPossibilidadeDeSaque(valorSolicitado));
        }

        [TestMethod]
        public void DeveRetornarTrueQuandoHouverPossibilidadeDeSaque()
        {
            double valorSolicitado = 20;

            Assert.IsTrue(CaixaEletronico.VerificarPossibilidadeDeSaque(valorSolicitado));
        }

        [TestMethod]
        public void DeveRetornarUmaNotaDeDezQuandoSolicitadoOSaqueDeDez()
        {
            int valorSolicitado = 10;
            var arrayEsperado = new int[]{10};

            Assert.IsTrue(CaixaEletronico.EfetuarSaque(valorSolicitado).Except(arrayEsperado).Count() == 0);
        }

        [TestMethod]
        public void DeveRetornarUmaNotaDeVinteQuandoSolicitadoOSaqueDeVinte()
        {
            int valorSolicitado = 20;
            var arrayEsperado = new int[] { 20 };

            Assert.IsTrue(CaixaEletronico.EfetuarSaque(valorSolicitado).Except(arrayEsperado).Count() == 0);
        }

        [TestMethod]
        public void DeveEfetuarSaqueDe100()
        {
            var arrayEsperado = new int[] { 100 };

            Assert.IsTrue(CaixaEletronico.EfetuarSaque(100).Except(arrayEsperado).Count() == 0);
        }

        [TestMethod]
        public void DeveVerificarSeEhDivisivelPor100()
        {
            var valor =  300 ;

            Assert.IsTrue(CaixaEletronico.VerificarDivisivel(valor, 100));
        }

        [TestMethod]
        public void DeveEfetuarSaqueDe50()
        {
            var arrayEsperado = new int[] { 50 };

            Assert.IsTrue(CaixaEletronico.EfetuarSaque(50).Except(arrayEsperado).Count() == 0);
        }

        [TestMethod]
        public void DeveVerificarSeEhDivisivelPor50()
        {
            var valor = 50;

            Assert.IsTrue(CaixaEletronico.VerificarDivisivel(valor, 50));
        }
    }
}
