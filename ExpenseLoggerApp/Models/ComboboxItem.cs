namespace ExpenseLoggerApp.Models
{
    /// <summary>
    /// This class is used to create item template for ComboBoxControl.
    /// </summary>
    public class ComboBoxItem
    {
        // Text to be displayed.
        public string Text { get; set; }

        // Actual value will be stored in the DB.
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
