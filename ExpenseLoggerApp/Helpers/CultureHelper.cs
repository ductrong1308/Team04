using System.Globalization;

namespace ExpenseLoggerApp.Helpers
{
    public static class CultureHelper
    {
        public static CultureInfo UserPreferenceCulture(string currency)
        {
            if (string.IsNullOrEmpty(currency))
            {
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

                var regionInfo = new RegionInfo(cultureCode);
                var cultureInfo = new CultureInfo(cultureCode)
                {
                    NumberFormat =
                    {
                        CurrencySymbol = regionInfo.ISOCurrencySymbol,
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
