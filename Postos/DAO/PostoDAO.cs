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
    public class PostoDAO : IPostoDAO
    {
        protected readonly postos_dbContext _context;

        public PostoDAO(postos_dbContext context)
        {
            this._context = context;
        }

        public Posto GetPostoById(string id)
        {
            return _context.Posto.Where(p => p.PostoId.Equals(id)).FirstOrDefault();
        }

        public async Task<Posto> GetPostoByIdAsync(string id)
        {
            return await _context.Posto.Where(p => p.PostoId.Equals(id)).FirstOrDefaultAsync();
        }

        public List<Posto> GetPostosMaisCaros()
        {
            return _context.Posto.OrderByDescending(p => p.ValordeVenda).Skip(1).Take(20).ToList();
        }

        public List<Posto> GetPostosMaisBaratos()
        {
            return _context.Posto.OrderBy(p => p.ValordeVenda).Skip(1).Take(20).ToList();
        }

        public Posto PostoMaisCaro()
        {
            return _context
                .Posto
                .OrderByDescending(p => p.ValordeVenda)
                .First();
        }

        public Posto PostoMaisBarato()
        {
            return _context
               .Posto
               .OrderBy(p => p.ValordeVenda)
               .First();
        }

        public void SavePostoList(List<Posto> postos)
        {
            Console.WriteLine("Saving data...");
            var counter = 0;

            Action action = () =>
            {
                foreach (Posto posto in postos)
                {

                    if (GetPostoById(posto.PostoId) == null) {
                        _context.Add(posto);
                        _context.SaveChanges();
                        Console.WriteLine("Saved " + posto.Revenda);
                        counter++;
                    }             

                }

                Console.WriteLine("Save data successfully: " + counter + " items");

            };

            action.Invoke();

        }

        public void SavePosto(Posto posto)
        {
            _context.Posto.Add(posto);
            _context.SaveChangesAsync();
        }

        public void UpdatePosto(Posto posto)
        {
            _context.Entry(posto).State = EntityState.Modified;
            _context.Posto.Update(posto);
            _context.SaveChangesAsync();
        }
    }
}
