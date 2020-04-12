using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenEvaluation.Data
{
    public class EvaluateContext : DbContext
    {
        public EvaluateContext(DbContextOptions<EvaluateContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(Startup.ConnectionString);
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkContent> HomeworkContents { get; set; }
        public DbSet<HomeworkSubmit> HomeworkSubmits { get; set; }
        public DbSet<HomeworkScore> HomeworkScores { get; set; }
        public DbSet<HomeworkScoreItem> HomeworkScoreItems { get; set; }
    }
}
