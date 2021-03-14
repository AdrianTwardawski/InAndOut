using InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Data
{
    public class ApplicationDbContext : DbContext  // requires EntityFrameworkCore
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
                 public DbSet<Item> Items { get; set; } // creates Table of Items
                 public DbSet<Expense> Expenses { get; set; }
                 public DbSet<ExpenseType> ExpensesTypes { get; set; }
    }
}
