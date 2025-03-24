using Esercizio_U5_S3_L1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_U5_S3_L1.Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }

        public DbSet<Studente> Studenti {
            get; set;
        }
    }
}
