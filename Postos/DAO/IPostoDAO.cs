using Postos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.DAO
{
    public interface IPostoDAO
    {
        void SavePosto(Posto posto);
        void SavePostoList(List<Posto> postos);
        void UpdatePosto(Posto posto);
        List<Posto> GetPostosMaisCaros();
        List<Posto> GetPostosMaisBaratos();
        Posto GetPostoById(String id);
        Posto PostoMaisCaro();
        Posto PostoMaisBarato();

    }
}
