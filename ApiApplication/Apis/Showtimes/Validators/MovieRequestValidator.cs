using ApiApplication.Apis.Showtimes.Messages;
using FluentValidation;

namespace ApiApplication.Apis.Showtimes.Validators;

public class MovieRequestValidator : AbstractValidator<Movie>
{
    public MovieRequestValidator()
    {
        RuleFor(x => x.ImdbId).NotEmpty();
    }    
}