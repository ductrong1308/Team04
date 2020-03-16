
using System.Globalization;

namespace ExpenseLoggerApp.Helpers
{
    public static class LoginInfo
    {
        public static int UserId { get; set; }

        public static string UserFirstName { get; set; }

        public static string UserLastName { get; set; }

        public static string Currency { get; set; }

        public static CultureInfo UserPreferenceCulture { get; set; }
    }
}