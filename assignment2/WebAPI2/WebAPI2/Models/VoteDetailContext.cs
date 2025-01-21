using Microsoft.EntityFrameworkCore;

namespace WebAPI2.Models
{
  public class VoteDetailContext : DbContext
  {
    public VoteDetailContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<VoteDetail> VoteDetails { get; set; }
    public DbSet<OptionDetail> OptionDetails { get; set; }
  }
}
