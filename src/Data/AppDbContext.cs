using Microsoft.EntityFrameworkCore;

using Noted.Models;

namespace Noted.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Note> Notes { get; set; } = null!;
}
