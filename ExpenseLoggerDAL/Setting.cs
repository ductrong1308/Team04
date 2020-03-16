namespace ExpenseLoggerDAL
{
    using System.ComponentModel.DataAnnotations;

    public partial class Setting
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Value { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
