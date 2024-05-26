using Project.Database.Context;
using Project.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Project.Database.Dtos.Request;
using Project.Database.Dtos.Common;
using Project.Database.Enums;
using Project.Database.QueryExtensions;


namespace Project.Database.Repositories
{
    public class ProdusRepository: BaseRepository
    {
   

        public ProdusRepository(ProjectDbContext labProjectDbContext) :base(labProjectDbContext)
        {
            
        }

        public Produs GetProdusById(int id)
        {
            return labProjectDbContext.Produse.FirstOrDefault(p => p.Id == id);
        }

        public void AddProdus(Produs produs)
        {
            labProjectDbContext.Produse.Add(produs);
            labProjectDbContext.SaveChanges();
        }

        public void UpdateProdus(Produs produs)
        {
            labProjectDbContext.Entry(produs).State = EntityState.Modified;
            labProjectDbContext.SaveChanges();
        }

        public void DeleteProdus(int id)
        {
            var produs = labProjectDbContext.Produse.Find(id);
            if (produs != null)
            {
                labProjectDbContext.Produse.Remove(produs);
                labProjectDbContext.SaveChanges();
            }
        }
       
        public List<Produs> GetAllProduse(GetProduseRequest payload)
        {
            var query = labProjectDbContext.Produse
                .Where(p => p.DateDeleted == null);

            
            query = query.Include(p => p.Reviews);

            if (!string.IsNullOrEmpty(payload.Nume))
            {
                query = query.Where(p => p.Nume.Contains(payload.Nume));
            }

            if (payload.Pret.HasValue && payload.Pret!=0)
            {
                query = query.Where(p => p.Pret == payload.Pret);
            }

            
            query = QueryableExtensions.Sort(query,payload.SortingCriterion);

            
            return query.AsNoTracking().ToList();
        }
        public int CountProduse(GetProduseRequest payload)
        {
            var count = GetAllProduse(payload)
                .Count();

            return count;
        }
    }
}
