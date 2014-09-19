using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
 
namespace ConsultaWay2
{

    public struct DadosDaConsulta
    {
        public bool Encontrada;
        public long PosicaoDaPalavra; 
        public long QuantidadeDeConsultas; 
    }

    public static class ServicoWay2
    {
        private struct DadosDaPesquisa 
        {
            public long LimiteInicial; 
            public long LimiteFinal; 
            public long QuantidadeDeConsultas; 
        }

        private static DadosDaPesquisa DefinirLimitesParaPesquisa(string nome)
        {
            DadosDaPesquisa dadosDaPesquisa = new DadosDaPesquisa();
            dadosDaPesquisa.LimiteInicial = 0;
            dadosDaPesquisa.LimiteFinal   = 0;
            dadosDaPesquisa.QuantidadeDeConsultas = 0;
            
            long indiceAtual = dadosDaPesquisa.LimiteInicial;

            while (true)
	        {
                string nomeEncontrado; 

                try
                {
                    dadosDaPesquisa.QuantidadeDeConsultas++;
                    nomeEncontrado = ServicoWay2.pesquisarPorIndice(indiceAtual); 
                }
                catch ( ArgumentOutOfRangeException )
                {
                    indiceAtual = dadosDaPesquisa.LimiteInicial + ((indiceAtual - dadosDaPesquisa.LimiteInicial) / 2);
                    continue;
                }
                catch ( Exception )
                {
                    throw;
                }

                int resultadoDaComparacao = String.Compare(nomeEncontrado, nome, true); 

                if ( resultadoDaComparacao == 0 )       // Encontrou a palavra
                { 
                    dadosDaPesquisa.LimiteInicial = indiceAtual;
                    dadosDaPesquisa.LimiteFinal   = indiceAtual;
                    break;
                }
                else if (resultadoDaComparacao < 0)   // Esta antes da palavra na lista 
                {
                    dadosDaPesquisa.LimiteInicial = indiceAtual;
                    indiceAtual = indiceAtual == 0 ? 1 : ( indiceAtual * 2 ); 
                    dadosDaPesquisa.LimiteFinal   = indiceAtual;
                }
                else if (resultadoDaComparacao > 0)   // Passou da palavra na lista 
                {
                    dadosDaPesquisa.LimiteFinal   = indiceAtual;
                    break;
                }
	        } 

            return dadosDaPesquisa;
        }

        public static DadosDaConsulta pesquisarPorNome( string nome )
        {            
            DadosDaPesquisa dadosDaPesquisa = ServicoWay2.DefinirLimitesParaPesquisa(nome);

            long indiceAtual;
            
            DadosDaConsulta dadosDaConsulta;

            do
            {
                indiceAtual = (long)(dadosDaPesquisa.LimiteInicial + dadosDaPesquisa.LimiteFinal) / 2;

                dadosDaConsulta = new DadosDaConsulta(){ PosicaoDaPalavra = indiceAtual, 
                                                         QuantidadeDeConsultas = dadosDaPesquisa.QuantidadeDeConsultas };

                string nomeEncontrado = ServicoWay2.pesquisarPorIndice(indiceAtual); 

                int resultadoDaComparacao = String.Compare(nomeEncontrado, nome, true); 
                
                if (resultadoDaComparacao == 0)       // Encontrou a palavra
                {
                    dadosDaConsulta.Encontrada = true;
                    return dadosDaConsulta;
                }
                else if (resultadoDaComparacao < 0)     // Esta antes da palavra na lista 
                {
                    dadosDaPesquisa.LimiteInicial = indiceAtual + 1;
                }
                else if ( resultadoDaComparacao > 0 )   // Esta antes da palavra na lista 
                {
                    dadosDaPesquisa.LimiteFinal = indiceAtual - 1;
                }
                
                dadosDaPesquisa.QuantidadeDeConsultas++;

            } while ( dadosDaPesquisa.LimiteInicial <= dadosDaPesquisa.LimiteFinal );

            dadosDaConsulta.Encontrada = false;
            return dadosDaConsulta;
        }

        public static string pesquisarPorIndice( long indice )
        {
            try
            {
			    WebRequest webRequest = WebRequest.Create( "http://teste.way2.com.br/dic/api/words/"+indice.ToString() );
                Stream responseStream = webRequest.GetResponse().GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                var resultadoDaConsulta = streamReader.ReadLine();  

                return resultadoDaConsulta.ToString(); 
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException(); 
            }
        } 
    }
}
