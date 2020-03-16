using System.Globalization;

namespace ExpenseLoggerApp.Helpers
{
    public static class CultureHelpers
    {
        public static CultureInfo UserPreferenceCulture(string currency)
        {
            if (string.IsNullOrEmpty(currency))
            {
                return CultureInfo.GetCultureInfo("en-US");
            }
            else
            {
                string cultureCode = "";
                switch (currency)
                {
                    case "$":
                        cultureCode = "en-US";
                        break;

                    case "€":
                        cultureCode = "fr-FR";
                        break;

                    case "£":
                        cultureCode = "en-GB";
                        break;
                }

                return CultureInfo.GetCultureInfo(cultureCode);
            }
        }
    }
}
