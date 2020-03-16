namespace ExpenseLoggerDAL
{
    using System.ComponentModel.DataAnnotations;

    public partial class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
