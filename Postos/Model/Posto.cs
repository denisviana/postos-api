using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.Model
{
    public class Posto
    {
        String Uid { get; set; }
        String Estado { get; set; }
        String Municipio { get; set; }
        String Nome { get; set; }
        String Bandeira { get; set; }
        double ValorVenda { get; set; }
        double ValorCompra { get; set; }
    }
}
