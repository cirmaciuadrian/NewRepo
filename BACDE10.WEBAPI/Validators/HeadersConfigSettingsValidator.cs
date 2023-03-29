using BACDE10.BusinessLogic.Models.Options;
using FluentValidation;

namespace BACDE10.WEBAPI.Validators;

public class HeadersConfigSettingsValidator : AbstractValidator<HeadersConfigSettings>
{
    public HeadersConfigSettingsValidator()
    {
        RuleFor((HeadersConfigSettings x) => x.Whitelist).Must((string? x) => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x));
    }
}
