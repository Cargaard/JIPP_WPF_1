using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace dbOperations
{
    public class ConvertersHistoryDataContext: DbContext
    {
        public DbSet<Converters> Converters { get; set; }
        public DbSet<History> History { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.\\BAZADANYCH;Initial Catalog=ConverterUsageHistory;Integrated Security=true");
        }
    }
}
