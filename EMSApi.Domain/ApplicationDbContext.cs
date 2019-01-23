using EMSApi.Entity;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Domain
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseLoggerFactory(MyLoggerFactory);

        public DbSet<User> Users { get; set; }

        public DbSet<Build> Builds { get; set; }

        public DbSet<UserBuilds> UserBuilds { get; set; }

        public DbSet<Circuit> Circuits { get; set; }

        public DbSet<Meter> Meters { get; set; }

        public DbSet<ParamInfo> ParamInfo { get; set; }

        public DbSet<EnergyItem> EnergyItem { get; set; }

        public DbSet<DayResult> DayResult { get; set; }

        public DbSet<HourResult> HourResult { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserBuilds>().HasKey(ub => new { ub.BuildId, ub.UserName });

            builder.Entity<DayResult>().HasKey(dr => new { dr.MeterId, dr.MeterParamId, dr.StarDay });

            builder.Entity<HourResult>().HasKey(hr => new { hr.MeterId, hr.MeterParamId, hr.StartHour });

        }

    }
}
