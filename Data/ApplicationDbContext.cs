using Microsoft.EntityFrameworkCore;
using TheFillingStation.Entities;
using TheFillingStation.Areas.Admin.Models;

namespace TheFillingStation.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
}