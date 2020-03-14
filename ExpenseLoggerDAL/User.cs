namespace ExpenseLoggerDAL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User : BaseEntity
    {
        public User()
        {
            Categories = new HashSet<Category>();
            Expenses = new HashSet<Expense>();
            Settings = new HashSet<Setting>();
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        public bool Gender { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }
    }
}
