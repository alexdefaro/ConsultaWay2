using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaWay2
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Qual palavra deseja pesquisar? ");
            string palavraParaPesquisar = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Aguarde....");

            DadosDaConsulta dadosDaConsulta = ServicoWay2.pesquisarPorNome(palavraParaPesquisar);             
            
            Console.WriteLine("");

            if ( dadosDaConsulta.Encontrada == true )
                Console.WriteLine("A palavra "+palavraParaPesquisar+" esta localizada na posição "+dadosDaConsulta.PosicaoDaPalavra.ToString()+" do dicionário.");
            else
                Console.WriteLine("A palavra "+palavraParaPesquisar+" não foi encontrada no dicionário.");

            Console.WriteLine("Para tentar encontrá-la foram mortos "+dadosDaConsulta.QuantidadeDeConsultas.ToString()+" gatinhos.");
            Console.WriteLine("");
            Console.WriteLine("Tecle <Enter> para terminar o programa");
            Console.Read();
        }
    }
}
