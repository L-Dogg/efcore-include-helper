using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfIncluder.Tests
{
    public class Tests : IDisposable
    {
        class MainModel
        {
            public int Id { get; set; }
            public int LinkedModelId { get; set; }
            [Include]
            public virtual LinkedModel LinkedModel { get; set; }
        }

        class LinkedModel
        {
            public int Id { get; set; }
            [Include]
            public virtual ICollection<MainModel> MainModels { get; set; }
        }

        class TestContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryDb");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<LinkedModel>().HasData(new LinkedModel {Id = 1});
                modelBuilder.Entity<LinkedModel>().HasData(new LinkedModel {Id = 2});
                modelBuilder.Entity<MainModel>().HasData(new MainModel {Id = 1, LinkedModelId = 1});
                modelBuilder.Entity<MainModel>().HasData(new MainModel {Id = 2, LinkedModelId = 1});
                modelBuilder.Entity<MainModel>().HasData(new MainModel {Id = 3, LinkedModelId = 2});
            }

            public virtual DbSet<MainModel> MainModels { get; set; }
            public virtual DbSet<LinkedModel> LinkedModels { get; set; }
        }

        private readonly TestContext _context;

        public Tests()
        {
            _context = new TestContext();
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task ShouldIncludeOneProperty()
        {
            var modelsWithInclude = await _context.MainModels.IncludeMarkedProperties().ToListAsync();
            modelsWithInclude.All(m => m.LinkedModel != null).Should().BeTrue();
        }

        [Fact]
        public async Task ShouldNotModifyDefaultBehaviour()
        {
            var modelsWithoutInclude = await _context.MainModels.ToListAsync();
            modelsWithoutInclude.All(m => m.LinkedModel == null).Should().BeTrue();
        }
    }
}