using System.Globalization;

namespace ExpenseLoggerApp.Helpers
{
    /// <summary>
    /// This class is implemented following the singleton pattern.
    /// This implementation is thread-safe. 
    /// The thread takes out a lock on a shared object, and then checks whether or not
    /// the instance has been created before creating the instance
    /// 
    /// This is a shared class which used to store user information, which will be used cross class in the application
    /// </summary>
    public sealed class UserIdentity
    {
        private static UserIdentity instance = null;

        private static readonly object padlock = new object();

        private UserIdentity()
        {
        }

        public static UserIdentity Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserIdentity();
                    }
                }

                return instance;
            }
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Currency { get; set; }

        public CultureInfo UserPreferenceCulture { get; set; }
    }
}
