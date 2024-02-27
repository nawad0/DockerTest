using DockerTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerTest.Data
{

    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Test> Tests;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Пример добавления одной статьи и нескольких лайков
            modelBuilder.Entity<Test>().HasData(
                new Test
                {
                    Id = 1,
                    Name = "dsadsadsa"
                   
                }
            );
        }


        }
}
