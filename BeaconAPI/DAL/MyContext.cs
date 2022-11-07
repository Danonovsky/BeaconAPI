using BeaconAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeaconAPI.DAL;

public class MyContext : DbContext
{
    public DbSet<Beacon> Beacons { get; set; }
    public DbSet<Place> Places { get; set; }

    public MyContext(DbContextOptions options) : base(options) { }
    public MyContext(): base(){}
}
