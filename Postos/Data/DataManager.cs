using Postos.DAO;
using Postos.Facade;
using Postos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Postos.Data
{
    public class DataManager : IDataManager
    {

        private const String URL = "http://www.anp.gov.br/arquivos/dadosabertos/precos/precos-semanais_ultimas-4-semanas_gasolina-etanol.csv";
        private const String PATH = @"wwwroot\csv\postos.txt";
        private readonly IPostoDAO _postoDAO;
        private static PostoFacade postoFacade;
        public DataManager(IPostoDAO postoDAO)
        {
            _postoDAO = postoDAO;
            postoFacade = new PostoFacade();
        }


        public async Task DownloadFileAsync()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());

            string firstLine = streamReader.ReadLine();
            string firstLineWithouSpecialCharacters = removerAcentos(firstLine)
                .Replace("-","")
                .Replace(" ","")
                .Replace("\t", ",");

            string results = streamReader.ReadToEnd()
                .Replace("\"","")
                .Replace(",",".")
                .Replace("\t",",")
                .Replace(" / ","/");

            streamReader.Close();

            string file = new StringBuilder()
                .AppendLine(firstLineWithouSpecialCharacters)
                .Append(results)
                .ToString()
                .Replace("\r","");

            File.WriteAllText(PATH, file);

            treatFile(PATH);
        }

        private void treatFile(String path)
        {
            var json = postoFacade.CSVtoJson(path);
            List<Posto> postos = postoFacade.JsonParse(json);
            var filtered = postos.Where(p => p.Produto.Equals("GASOLINA")).ToList();
            _postoDAO.SavePostoList(filtered);

            Console.Write(postos);
        }

        public static string removerAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        }

    }
}
