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
    public class DataManager
    {

        private const String URL = "http://www.anp.gov.br/arquivos/dadosabertos/precos/precos-semanais_ultimas-4-semanas_gasolina-etanol.csv";
        private const String PATH = @"c:\temp\postos.txt";
        private static PostoDAO postoDAO;
        private static PostoFacade postoFacade;

        private static DataManager instance;

        private DataManager() { }

        public static DataManager getInstance()
        {
            if (postoDAO == null) postoDAO = new PostoDAO();
            if (postoFacade == null) postoFacade = new PostoFacade();
            if (instance == null) instance = new DataManager();

            return instance;
        }

        public async Task DownloadFileAsync()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string results = streamReader.ReadToEnd().Replace("\t",",");
            streamReader.Close();

            treatFile(results);
        }

        private void treatFile(String path)
        {

            String json = postoFacade.CSVtoJson(path);
            List<Posto> postos = postoFacade.JsonParse(json);

        }

    }
}
