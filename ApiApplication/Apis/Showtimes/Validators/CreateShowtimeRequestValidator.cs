using System;
using System.Globalization;
using System.Linq;
using ApiApplication.Apis.Showtimes.Messages;
using FluentValidation;

namespace ApiApplication.Apis.Showtimes.Validators;

public class CreateShowtimeRequestValidator : AbstractValidator<CreateShowtimeRequest>
{
    public CreateShowtimeRequestValidator()
    {
        RuleFor(x => x.AuditoriumId).NotEmpty();
        RuleFor(x => x.Movie).SetValidator(new MovieRequestValidator());
        RuleFor(x => x.Schedule)
            .Must(v => v.All(h => DateTime.TryParseExact(h, "hh:mm" , new CultureInfo("en-US"), DateTimeStyles.None, out _)))
            .WithMessage("invalid schedule value");
    }
}