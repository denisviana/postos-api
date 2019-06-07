using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.DAO
{
    public class BaseDAO
    {
        private static Context criar;

        

        public static Context GetInstance()
         {

            if (criar == null)
                {
                criar = new Context();
                } 
               return criar;

         }

    }
}
