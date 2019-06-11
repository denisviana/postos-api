using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.Data
{
    public interface IDataManager
    {
        Task DownloadFileAsync();
    }
}
