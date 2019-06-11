using Postos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.DAO
{
    public class BaseDAO
    {

        protected readonly postos_dbContext _context;

        public BaseDAO(postos_dbContext context)
        {
            _context = context;
        }

    }
}
