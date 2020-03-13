namespace ExpenseLoggerDAL
{
    using System.ComponentModel.DataAnnotations;

    public partial class Setting : BaseEntity
    {
        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Value { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
