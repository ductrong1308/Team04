namespace ExpenseLoggerDAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expenses")]
    public partial class Expense : BaseEntity
    {
        public DateTime ExpenseOnDate { get; set; }

        public int CategoryId { get; set; }

        public int UserID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
