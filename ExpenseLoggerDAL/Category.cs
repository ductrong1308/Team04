namespace ExpenseLoggerDAL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Category : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
