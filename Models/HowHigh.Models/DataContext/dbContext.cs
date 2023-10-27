using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowHigh.Models.DataContext
{
    public class dbContext : DbContext
    {

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<HowHigh.Models.Models.Users> Users
        {
            get;
            set;
        }
        public DbSet<HowHigh.Models.Models.ThrowHistories> ThrowHistories
        {
            get;
            set;
        }

    }
}
