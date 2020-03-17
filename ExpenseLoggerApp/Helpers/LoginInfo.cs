using System.Globalization;

namespace ExpenseLoggerApp.Helpers
{
    /// <summary>
    /// This is a shared class which used to store user information 
    /// This will be used cross class in the application.
    /// </summary>
    public static class LoginInfo
    {
        public static int UserId { get; set; }

        public static string UserFirstName { get; set; }

        public static string UserLastName { get; set; }

        public static string Currency { get; set; }

        public static CultureInfo UserPreferenceCulture { get; set; }
    }
}