using System;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    internal static class ValidationHelper
    {
        private static readonly Regex PersonNamePattern =
            new Regex(@"^[\p{L}][\p{L}\s'-]{0,49}$", RegexOptions.Compiled);

        private static readonly Regex TitlePattern =
            new Regex(@"^[\p{L}\p{N}][\p{L}\p{N}\s&'().,-]{0,49}$", RegexOptions.Compiled);

        internal static bool IsPersonName(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && PersonNamePattern.IsMatch(value.Trim());
        }

        internal static bool IsTitle(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && TitlePattern.IsMatch(value.Trim());
        }

        internal static bool IsEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100 || value.Contains(" "))
            {
                return false;
            }

            try
            {
                MailAddress address = new MailAddress(value);
                return string.Equals(address.Address, value, StringComparison.OrdinalIgnoreCase);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        internal static bool IsPhone(string value)
        {
            return value != null && value.Length == 10 && value.All(char.IsDigit);
        }

        internal static bool IsWebsite(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 100 || value.Contains(" "))
            {
                return false;
            }

            string candidate = value.Contains("://") ? value : "https://" + value;
            Uri uri;
            return Uri.TryCreate(candidate, UriKind.Absolute, out uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
                && uri.Host.Contains(".");
        }

        internal static bool HasRequiredText(string value, int maximumLength, int minimumLength = 1)
        {
            if (value == null)
            {
                return false;
            }

            int length = value.Trim().Length;
            return length >= minimumLength && length <= maximumLength;
        }

        internal static bool TryReadPositiveMoney(string value, out decimal amount)
        {
            return (decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out amount)
                    || decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
                && amount > 0;
        }

        internal static bool TryReadPositiveInt(string value, out int number)
        {
            return int.TryParse(value, out number) && number > 0;
        }

        internal static bool TryReadOptionalRating(string value, out decimal? rating)
        {
            rating = null;
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            decimal parsed;
            bool validNumber = decimal.TryParse(
                    value,
                    NumberStyles.Number,
                    CultureInfo.CurrentCulture,
                    out parsed)
                || decimal.TryParse(
                    value,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out parsed);

            if (!validNumber || parsed < 0 || parsed > 10 || decimal.Round(parsed, 2) != parsed)
            {
                return false;
            }

            rating = parsed;
            return true;
        }

        internal static bool TryGetSelectedId(ComboBox comboBox, out int id)
        {
            id = 0;
            if (comboBox == null || comboBox.SelectedIndex < 0 || comboBox.SelectedValue == null)
            {
                return false;
            }

            try
            {
                id = Convert.ToInt32(comboBox.SelectedValue, CultureInfo.InvariantCulture);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
    }
}
