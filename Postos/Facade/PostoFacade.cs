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
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(@path);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }
    }
}
