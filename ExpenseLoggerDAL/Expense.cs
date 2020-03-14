namespace ExpenseLoggerDAL
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Expenses")]
    public partial class Expense : BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public string CategoryName { get; set; }

        public decimal Amount { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
