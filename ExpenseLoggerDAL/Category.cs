namespace ExpenseLoggerDAL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Category : BaseEntity
    {
        public Category()
        {
            Expenses = new HashSet<Expense>();
        }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
