namespace ExpenseLoggerDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExpenseLoggerDBContext : DbContext
    {
        public ExpenseLoggerDBContext()
            : base("name=ExpenseLoggerConnection")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
