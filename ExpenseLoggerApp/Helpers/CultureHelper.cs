using System.Globalization;

namespace ExpenseLoggerApp.Helpers
{
    /// <summary>
    /// This class is used to help the application to display the currency based on what user prefer.
    /// </summary>
    public static class CultureHelper
    {
        public static CultureInfo UserPreferenceCulture(string currency)
        {
            if (string.IsNullOrEmpty(currency))
            {
                // By default the culter will be Canada.
                return CultureInfo.GetCultureInfo("en-CA");
            }
            else
            {
                string cultureCode = "";
                switch (currency)
                {
                    case "CAD":
                        cultureCode = "en-CA";
                        break;

                    case "USD":
                        cultureCode = "en-US";
                        break;

                    case "EUR":
                        cultureCode = "fr-FR";
                        break;

                    case "GBP":
                        cultureCode = "en-GB";
                        break;

                    case "CNY":
                        cultureCode = "zh-CN";
                        break;

                    case "JPY":
                        cultureCode = "ja-JP";
                        break;
                }

                // Create Culture info.
                var regionInfo = new RegionInfo(cultureCode);
                var cultureInfo = new CultureInfo(cultureCode)
                {
                    NumberFormat =
                    {
                        CurrencySymbol = regionInfo.CurrencySymbol,
                        // make sure, the symbol is placed in front of the number with an additional empty space
                        CurrencyPositivePattern = 2,
                        //does the same for negative values
                        CurrencyNegativePattern = 12
                    }
                };

                return cultureInfo;
            }
        }
    }
}
