using HouseFunSKA.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseFunSKA.Data;

public class NorthwindContext : DbContext
{
   public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options){}
   
   public DbSet<Customer> Customers { get; set; }
}