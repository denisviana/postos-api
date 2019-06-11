using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.Model
{
    [Table("Posto")]
    public class Posto : EntidadeBase
    {
        [Key]
        [JsonProperty(PropertyName = "InstalacaoCodigo")]
        public string PostoId { get; set; }
        [JsonProperty(PropertyName = "Revenda")]
        public string Revenda { get; set; }
        [JsonProperty(PropertyName = "EstadoSigla")]
        public string Estado { get; set; }
        [JsonProperty(PropertyName = "Municipio")]
        public string Municipio { get; set; }
        public string Produto { get; set; }
        [JsonProperty(PropertyName = "Bandeira")]
        public string Bandeira { get; set; }
        [JsonProperty(PropertyName = "ValordeVenda")]
        public string ValordeVenda { get; set; }
        [JsonProperty(PropertyName = "ValordeCompra")]
        public string ValordeCompra { get; set; }
    }
}
