using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.Model
{
    public class Posto : EntidadeBase
    {
        String PostoId { get; set; }
        String Revenda { get; set; }
        [JsonProperty(PropertyName = "Estado - Sigla")]
        String Estado { get; set; }
        [JsonProperty(PropertyName = "Município")]
        String Municipio { get; set; }
        String Produto { get; set; }
        String Bandeira { get; set; }
        [JsonProperty(PropertyName = "Valor de Venda")]
        double ValorVenda { get; set; }
        [JsonProperty(PropertyName = "Valor de Compra")]
        double ValorCompra { get; set; }
    }
}
