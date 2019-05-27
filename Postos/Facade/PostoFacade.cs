using ChoETL;
using CsvHelper;
using Newtonsoft.Json;
using Postos.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postos.Facade
{
    public class PostoFacade
    {
        public List<Posto> JsonParse(String json)
        {
            return JsonConvert.DeserializeObject<List<Posto>>(json);
        }

        public String CSVtoJson(String path)
        {
            //var csv = new List<string[]>();
            //var lines = File.ReadAllLines(path);

            try
            {

                System.IO.File.WriteAllText(@"c:\temp\postos.txt", path);

                StringBuilder sb = new StringBuilder();
                foreach (dynamic e in new ChoCSVReader(@"c:\temp\postos.txt").WithFirstLineHeader())
                    Console.WriteLine(e.Bandeira);
               

                //Console.WriteLine(sb.ToString());
                return sb.ToString();
            }
            catch(Exception e)
            {
                Console.Write(e);
                return null;
            }
        }
    }
}
