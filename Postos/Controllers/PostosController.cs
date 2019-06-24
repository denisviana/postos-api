using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postos.Context;
using Postos.DAO;
using Postos.Model;

namespace Postos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostosController : ControllerBase
    {
        private readonly IPostoDAO _postoDAO;

        public PostosController(IPostoDAO postoDAO)
        {
            _postoDAO = postoDAO;
        }

        // GET: api/Postos
        [HttpGet("top20/maiscaros")]
        public IEnumerable<Posto> GetPostosMaisCaros()
        {
            return _postoDAO.GetPostosMaisCaros();
        }

        [HttpGet("top20/maisbaratos")]
        public IEnumerable<Posto> GetPostosMaisBaratos()
        {
            return _postoDAO.GetPostosMaisBaratos();
        }

        [HttpGet("maiscaro")]
        public ActionResult PostoMaisCaro()
        {
            return Ok(_postoDAO.PostoMaisCaro());
        }

        [HttpGet("maisbarato")]
        public ActionResult PostoMaisBarato()
        {
            return Ok(_postoDAO.PostoMaisBarato());
        }

    }
}