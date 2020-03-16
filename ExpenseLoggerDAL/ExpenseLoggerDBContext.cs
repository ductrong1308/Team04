namespace ExpenseLoggerDAL
{
    using System.Data.Entity;

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
            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
