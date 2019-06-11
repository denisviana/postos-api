using Microsoft.EntityFrameworkCore;
using Postos.Context;
using Postos.Controllers;
using Postos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postos.DAO
{
    public class PostoDAO : BaseDAO, IPostoDAO
    {

        public PostoDAO(postos_dbContext context) : base(context)
        {
        }

        public Posto GetPostoById(string id)
        {
            return _context.Posto.Where(p => p.PostoId.Equals(id)).FirstOrDefault();
        }

        public List<Posto> GetPostos()
        {
            return _context.Posto.ToList();
        }

        public void SavePostoList(List<Posto> postos)
        {
            Console.WriteLine("Saving data...");

            foreach (Posto posto in postos)
            {
                if (GetPostoById(posto.PostoId) != null)
                    UpdatePosto(posto);
                else
                    SavePosto(posto);
            }

            _context.SaveChangesAsync();

            Console.WriteLine("Save data successfully");
        }

        public void SavePosto(Posto posto)
        {
            _context.Posto.Add(posto);
        }

        public void UpdatePosto(Posto posto)
        {
            _context.Entry(posto).State = EntityState.Modified;
            _context.Posto.Update(posto);
        }
    }
}
