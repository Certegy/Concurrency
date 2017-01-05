using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Concurrency.Models;

namespace Concurrency
{
    public class DatabaseContext: DbContext
    {
        private bool isOracle;

        public DatabaseContext(bool isOracle = true): base(isOracle ? "Oracle" : "SqlServer")
        {
            Database.Log = Console.Write;
            this.isOracle = isOracle;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AttachEntities(modelBuilder);
        }

        private void AttachEntities(DbModelBuilder modelBuilder)
        {
            AttachEntityToDbModel<UnitTest, int>(modelBuilder, "ZZ_UNIT_TEST");
        }

        protected void AttachEntityToDbModel<TEntity, TKey>(DbModelBuilder modelBuilder, string tableName) where TEntity : Entity<TKey>, IEntity<TKey>
        {
            modelBuilder.Entity<TEntity>().ToTable(tableName, isOracle ? "EZIAUS" : "dbo");

            if (isOracle)
            {
                modelBuilder.Entity<TEntity>().Property(x => x.RowVersion).IsConcurrencyToken(true);
                modelBuilder.Entity<TEntity>().Property(x => x.RowIdentifier).HasColumnType("ROWID");
                modelBuilder.Entity<TEntity>().Ignore(x => x.Timestamp);
            }
            else
            {
                modelBuilder.Entity<TEntity>().Property(x => x.Timestamp).IsRowVersion();
                modelBuilder.Entity<TEntity>().Ignore(x => x.RowVersion);
                modelBuilder.Entity<TEntity>().Ignore(x => x.RowIdentifier);
            }
        }
    }
}
