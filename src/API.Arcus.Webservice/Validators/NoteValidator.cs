using API.Arcus.Infrastructure.Dto.Note;
using FluentValidation;

namespace API.Arcus.Webservice.Validators
{
	public class NoteValidator : AbstractValidator<NotePostRequestDto>
	{
		public NoteValidator()
		{
			RuleFor(x => x.NoteText)
				.NotNull()
				.MinimumLength(2)
				.MaximumLength(1000)
				.WithMessage("The note's length must be between 2 and 1000 characters");
		}
	}
}