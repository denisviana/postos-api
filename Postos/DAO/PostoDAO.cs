using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.DAO
{
    public class PostoDAO : BaseDAO
    {

        private static Context criar = SingletonContext.GetInstance();

        public Lista<Posto> pegarTodosItens()
            {
            return null;
            }

        public Posto pegarItemPorId(string id)
           {
           return null;
           }    
        public void salvarDados(List<Posto> dados)
            {
            }
        public void deletarItem(string id)
            {
            }
        public void atualizarItem(Posto posto)
            {
            }
    }
}
