using ApiApplication.Apis.Showtimes.Messages;
using FluentValidation;

namespace ApiApplication.Apis.Showtimes.Validators;

public class CreateShowtimeRequestValidator : AbstractValidator<CreateShowtimeRequest>
{
    public CreateShowtimeRequestValidator()
    {
        RuleFor(x => x.AuditoriumId).NotEmpty();
        RuleFor(x => x.Movie).SetValidator(new MovieRequestValidator());
    }
}