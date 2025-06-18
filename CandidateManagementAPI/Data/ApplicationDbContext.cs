using CandidateManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }
    }
}
