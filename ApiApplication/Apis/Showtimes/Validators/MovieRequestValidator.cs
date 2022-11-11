using ApiApplication.Apis.Showtimes.Messages;
using FluentValidation;

namespace ApiApplication.Apis.Showtimes.Validators;

public class MovieRequestValidator : AbstractValidator<MovieRequest>
{
    public MovieRequestValidator()
    {
        RuleFor(x => x.ImdbId).NotEmpty();
    }    
}