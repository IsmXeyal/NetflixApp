using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Services.Validations;

public class PhoneValidationRuleService : ValidationRule
{
    public PhoneValidationRuleService()
    {
    }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string? valueString = value as string;
        if (valueString == null)
        {
            ErrorService.IsError = true;
            valueString = "";
        }
        if (valueString.Length == 0)
        {
            ErrorService.IsError = true;
            return new ValidationResult(false, $"Cannot empty");
        }
        else if (!Regex.IsMatch(valueString, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{2}[\s.-]\d{2}$"))
        {
            ErrorService.IsError = true;
            return new ValidationResult(false, $"Invalid format");
        }
        ErrorService.IsError = false;
        return new ValidationResult(true, null);
    }
}
