using Project.Database.Context;

namespace Project.Database.Repositories
{
    public class BaseRepository
    {
        protected ProjectDbContext labProjectDbContext { get; set; }

        public BaseRepository(ProjectDbContext labProjectDbContext)
        {
            this.labProjectDbContext = labProjectDbContext;
        }

        public void SaveChanges()
        {
            labProjectDbContext.SaveChanges();
        }
    }
}
