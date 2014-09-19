using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConsultaWay2;

namespace ConsultaWay2Test
{
    [TestClass]
    public class ServicoWay2Test
    {
        [TestMethod]
        public void pesquisarPorIndiceComIndex10DeveRetornarABADIA()
        {
            string resultadoDoServico = ServicoWay2.pesquisarPorIndice(10); 
            Assert.AreEqual( "ABADIA", resultadoDoServico );
        }

        [TestMethod]
        public void pesquisarPorIndiceComIndex150DeveRetornarABLUIREMO()
        {
            string resultadoDoServico = ServicoWay2.pesquisarPorIndice(150); 
            Assert.AreEqual( "ABLUIREMO", resultadoDoServico );
        }
         
        [TestMethod]
        public void pesquisarPorNomeComNomeABACATEIRODeveRetornar3()
        {
            DadosDaConsulta dadosDaConsulta = ServicoWay2.pesquisarPorNome("ABACATEIRO"); 
            Assert.AreEqual( 3, dadosDaConsulta.PosicaoDaPalavra );
        }

        [TestMethod]
        public void pesquisarPorNomeComNomeCHEGAREISDeveRetornar8005()
        {
            DadosDaConsulta dadosDaConsulta = ServicoWay2.pesquisarPorNome("CHEGAREIS"); 
            Assert.AreEqual( 8005, dadosDaConsulta.PosicaoDaPalavra );
        } 
        
        [TestMethod]
        public void pesquisarPorNomeComNomeACUDÍSSEISDeveRetornar899()
        {
            DadosDaConsulta dadosDaConsulta = ServicoWay2.pesquisarPorNome("ACUDÍSSEIS"); 
            Assert.AreEqual( 899, dadosDaConsulta.PosicaoDaPalavra );
        } 
        
        [TestMethod]
        public void pesquisarPorNomeComNomeTRADUZIRMODeveRetornar42001()
        {
            DadosDaConsulta dadosDaConsulta = ServicoWay2.pesquisarPorNome("TRADUZIRMO"); 
            Assert.AreEqual( 42001, dadosDaConsulta.PosicaoDaPalavra );
        }
        
    }
}
