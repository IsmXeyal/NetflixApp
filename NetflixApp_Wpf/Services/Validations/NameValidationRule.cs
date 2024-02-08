using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NetflixApp_Wpf.Services.Validations;

public class NameValidationRuleService : ValidationRule
{
    public NameValidationRuleService()
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
            return new ValidationResult(false, $"Cannot be empty");
        }
        else if (!Regex.IsMatch(valueString, @"^[A-Z][a-zA-Z]*$"))
        {
            ErrorService.IsError = true;
            return new ValidationResult(false, $"Invalid format.");
        }
        ErrorService.IsError = false;
        return new ValidationResult(true, null);
    }
}
