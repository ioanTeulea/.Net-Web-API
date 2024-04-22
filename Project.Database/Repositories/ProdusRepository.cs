using Project.Database.Context;
using Project.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Project.Database.Repositories
{
    public class ProdusRepository
    {
        private readonly ProjectDbContext _context;

        public ProdusRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produs> GetAllProduse()
        {
            return _context.Produse.ToList();
        }

        public Produs GetProdusById(int id)
        {
            return _context.Produse.FirstOrDefault(p => p.Id == id);
        }

        public void AddProdus(Produs produs)
        {
            _context.Produse.Add(produs);
            _context.SaveChanges();
        }

        public void UpdateProdus(Produs produs)
        {
            _context.Entry(produs).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProdus(int id)
        {
            var produs = _context.Produse.Find(id);
            if (produs != null)
            {
                _context.Produse.Remove(produs);
                _context.SaveChanges();
            }
        }
    }
}
