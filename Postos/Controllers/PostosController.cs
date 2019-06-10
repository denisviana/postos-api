using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Postos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostosController : ControllerBase
    {
        
       
        public List<Posto> GetPostos()
        {
            return PostoDAO.RetornarPostos();
        }

        public dynamic GetPostoPorId(int postoId)
        {
            Posto posto = PostoDAO.BuscarPostoPorId(postoId);
           
            if (posto != null)
            {
                dynamic postoDinamico = new
                {
                    PostoNome = posto.Nome,
                    Posto = posto
                };
                return new { Posto = postoDinamico };
            }
            return NotFound();
        }
    }
}
