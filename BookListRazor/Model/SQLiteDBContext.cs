using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using BookListRazor.Model;

namespace BookListRazor.Model
{
    public class SQLiteDBContext : DbContext
    {
        public SQLiteDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigContext cc = new ConfigContext();
            cc.MgzTitle = cc.GetPrdID();
            optionsBuilder.UseSqlite("FileName=./Database/"+cc.MgzTitle+".sqlite");
        }

        public DbSet<Prd> Products { get; set; }
    }

}
