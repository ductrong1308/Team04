using System.Net.Mail;

namespace ExpenseLoggerApp.Helpers
{
    /// <summary>
    /// This class contains methods which help the system to validate user's data.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Validate email address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
