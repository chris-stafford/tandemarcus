using API.Arcus.Domain.Model;
using FluentValidation;

namespace API.Arcus.Webservice.Validators
{
	public class UserValidator : AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.MaximumLength(1000)
				.EmailAddress()
				.WithMessage("The customer's email address must be valid'");

			RuleFor(x => x.FirstName)
				.NotNull()
				.MinimumLength(2)
				.MaximumLength(1000)
				.WithMessage("The customer first name must be between 2 and 1000 characters long");
				
			RuleFor(x => x.LastName)
				.NotNull()
				.MinimumLength(2)
				.MaximumLength(1000)
				.WithMessage("The customer last name must be between 2 and 1000 characters long");
		}
	}
}